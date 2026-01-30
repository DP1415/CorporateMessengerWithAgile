// src/components/UserLayout.tsx
import React, { useState, useEffect } from 'react';
import { Outlet, Link } from 'react-router-dom';
import { UserController } from '../controllers';
import styles from './UserLayout.module.css';
import type { Result, UserDto, EmployeeWithRelationsDto } from '../models';
import { AppError } from '../models';

interface UserLayoutProps {
    authUser: { token: string; user: UserDto };
}

export interface UserLayoutContext {
    authUser: { token: string; user: UserDto };
    employeesWithRelations: EmployeeWithRelationsDto[];
    loadingEmployeesWithRelations: boolean;
}

const UserLayout: React.FC<UserLayoutProps> = ({ authUser }) => {
    const [employeesWithRelations, setEmployeesWithRelations] = useState<EmployeeWithRelationsDto[] | null>(null);
    const [loadingEmployeesWithRelations, setLoadingEmployeesWithRelations] = useState(true);
    const [employeesWithRelationsError, setEmployeesWithRelationsError] = useState<AppError | null>(null);

    useEffect(() => {
        const fetchCompanies = async () => {
            const controller = new UserController();
            const result: Result<EmployeeWithRelationsDto[]> = await controller.getEmployeesWithRelations(authUser.user.id);
            if (result.isFailure) {
                setEmployeesWithRelations(null)
                setEmployeesWithRelationsError(result.error);
            } else {
                setEmployeesWithRelations(result.value);
                setEmployeesWithRelationsError(null);
            }
            setLoadingEmployeesWithRelations(false);
        };
        fetchCompanies();
    }, [authUser.user.id]);

    return (
        <div className={styles.userHomeLayout}>
            <aside className={styles.sidebar}>
                <nav>
                    <ul>
                        <li><Link to="/">Главная</Link></li>
                        <li><Link to="/profile">Профиль</Link></li>
                        {
                            employeesWithRelations && employeesWithRelations.length > 0 && (
                                <>
                                    <li className={styles.menuHeader}>Компании</li>
                                    {employeesWithRelations.map(
                                        employee => (
                                            <li key={employee.company.id}>
                                                <Link to={getCompanyRoute(employee.company.title)}>
                                                    {employee.company.title}
                                                </Link>
                                            </li>
                                        )
                                    )}
                                </>
                            )
                        }
                    </ul>
                </nav>
            </aside>

            <main className={styles.mainContent}>
                {
                    loadingEmployeesWithRelations ? (
                        <p>Загрузка данных...</p>
                    ) : (
                        <>
                            {employeesWithRelationsError && <p>Не удалось загрузить данные сотрудников: {employeesWithRelationsError.message}</p>}
                            <Outlet context={{ authUser, employeesWithRelations, loadingEmployeesWithRelations }} />
                        </>
                    )
                }
            </main>
        </div>
    );
};

export default UserLayout;

const getCompanyRoute = (companyTitle: string): string => {
    return `/company/${encodeURIComponent(companyTitle)}`;
};
