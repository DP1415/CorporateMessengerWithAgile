// src/layouts/userLayout/UserLayout.tsx
import React, { useState, useEffect } from 'react';
import { Outlet } from 'react-router-dom';
import { AppControllers, type EmployeeWithRelations } from '../../controllers';
import styles from './UserLayout.module.css';
import type { Result, UserSummaryDto } from '../../models';
import { AppError } from '../../models';
import SidebarMenu from './sidebarMenu/SidebarMenu';
import { AppErrorDisplay } from '../../components';

interface UserLayoutProps {
    controller: AppControllers;
    currentUser: UserSummaryDto;
}

export interface UserLayoutContext {
    controller: AppControllers;
    currentUser: UserSummaryDto;
    employeesWithRelations: EmployeeWithRelations[];
}

const UserLayout: React.FC<UserLayoutProps> = ({ controller, currentUser }) => {
    const [employeesWithRelations, setEmployeesWithRelations] = useState<EmployeeWithRelations[]>([]);
    const [loadingEmployeesWithRelations, setLoadingEmployeesWithRelations] = useState(true);
    const [employeesWithRelationsError, setEmployeesWithRelationsError] = useState<AppError | null>(null);

    useEffect(() => {
        const fetchCompanies = async () => {
            const result: Result<EmployeeWithRelations[]> = await controller.Employee.getEmployeesWithRelations();
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
    }, [currentUser.id, controller]);

    return (
        <div className={styles.userHomeLayout}>
            <SidebarMenu employeesWithRelations={employeesWithRelations} />
            <main className={styles.mainContent}>
                {
                    loadingEmployeesWithRelations
                        ? <p>Загрузка данных...</p>
                        : <>
                            {employeesWithRelationsError && <AppErrorDisplay error={employeesWithRelationsError} />}
                            <Outlet context={{ controller, currentUser, employeesWithRelations }} />
                        </>
                }
            </main>
        </div>
    );
};

export default UserLayout;
