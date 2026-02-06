// src/components/UserLayout.tsx
import React, { useState, useEffect } from 'react';
import { Outlet } from 'react-router-dom';
import { UserController, type EmployeeWithRelations } from '../controllers';
import styles from './UserLayout.module.css';
import type { Result, UserSummaryDto } from '../models';
import { AppError } from '../models';
import SidebarMenu from './SidebarMenu';

interface UserLayoutProps {
    authUser: { token: string; user: UserSummaryDto };
}

export interface UserLayoutContext {
    authUser: { token: string; user: UserSummaryDto };
    employeesWithRelations: EmployeeWithRelations[];
}

const UserLayout: React.FC<UserLayoutProps> = ({ authUser }) => {
    const [employeesWithRelations, setEmployeesWithRelations] = useState<EmployeeWithRelations[]>([]);
    const [loadingEmployeesWithRelations, setLoadingEmployeesWithRelations] = useState(true);
    const [employeesWithRelationsError, setEmployeesWithRelationsError] = useState<AppError | null>(null);

    useEffect(() => {
        const fetchCompanies = async () => {
            const controller = new UserController();
            const result: Result<EmployeeWithRelations[]> = await controller.getEmployeesWithRelations(authUser.user.id);
            if (result.isFailure) {
                setEmployeesWithRelations([])
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
            <SidebarMenu employeesWithRelations={employeesWithRelations} />

            <main className={styles.mainContent}>
                {
                    loadingEmployeesWithRelations
                        ? <p>Загрузка данных...</p>
                        : <>
                            {
                                employeesWithRelationsError &&
                                <p>Не удалось загрузить данные: {employeesWithRelationsError.message} ({employeesWithRelationsError.code})</p>
                            }
                            <Outlet context={{ authUser, employeesWithRelations }} />
                        </>
                }
            </main>
        </div>
    );
};

export default UserLayout;
