// src/components/user/UserLayout.tsx
import React, { useState, useEffect } from 'react';
import { Outlet } from 'react-router-dom';
import { UserController, type EmployeeWithRelations } from '../../controllers';
import styles from './UserLayout.module.css';
import type { Result, UserSummaryDto } from '../../models';
import { AppError } from '../../models';
import SidebarMenu from './SidebarMenu';

interface UserLayoutProps {
    userController: UserController;
    currentUser: UserSummaryDto;
}

export interface UserLayoutContext {
    userController: UserController;
    currentUser: UserSummaryDto;
    employeesWithRelations: EmployeeWithRelations[];
}

const UserLayout: React.FC<UserLayoutProps> = ({ userController, currentUser }) => {
    const [employeesWithRelations, setEmployeesWithRelations] = useState<EmployeeWithRelations[]>([]);
    const [loadingEmployeesWithRelations, setLoadingEmployeesWithRelations] = useState(true);
    const [employeesWithRelationsError, setEmployeesWithRelationsError] = useState<AppError | null>(null);

    useEffect(() => {
        const fetchCompanies = async () => {
            const result: Result<EmployeeWithRelations[]> = await userController.getEmployeesWithRelations(currentUser.id);
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
    }, [currentUser.id, userController]);

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
                            <Outlet context={{ userController, currentUser, employeesWithRelations }} />
                        </>
                }
            </main>
        </div>
    );
};

export default UserLayout;
