// src/components/UserLayout.tsx
import React, { useState, useEffect } from 'react';
import { Outlet, Link } from 'react-router-dom';
import { UserController } from '../controllers';
import styles from './UserLayout.module.css';
import type { Result, UserDto, WorkplaceDto } from '../models';

interface UserLayoutProps {
    authUser: { token: string; user: UserDto };
}

export interface UserLayoutContext {
    authUser: { token: string; user: UserDto };
    workplaces: WorkplaceDto[];
    loadingCompanies: boolean;
}

const UserLayout: React.FC<UserLayoutProps> = ({ authUser }) => {
    const [workplaces, setWorkplaces] = useState<WorkplaceDto[] | null>(null);
    const [loadingCompanies, setLoadingCompanies] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchCompanies = async () => {
            const controller = new UserController();
            const result: Result<WorkplaceDto[]> = await controller.getWorkplaces(authUser.user.id);
            if (result.isFailure) {
                setError(result.error?.message || 'Не удалось загрузить компании');
            } else {
                setWorkplaces(result.value);
                setError(null);
            }
            setLoadingCompanies(false);
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

                        <li className={styles.menuHeader}>Компании</li>

                        {
                            loadingCompanies ? (
                                <li>Загрузка...</li>
                            ) : error ? (
                                <li>Ошибка: {error}</li>
                            ) : workplaces && workplaces.length > 0 ? (
                                workplaces.map(
                                    w => (
                                        <li key={w.company.id}>
                                            <Link to={`/company/${w.company.title}`}>{w.company.title}</Link>
                                        </li>
                                    )
                                )
                            ) : (
                                <li>Нет доступных компаний</li>
                            )
                        }
                    </ul>
                </nav>
            </aside>

            <main className={styles.mainContent}>
                <Outlet context={{ authUser, workplaces, loadingCompanies }} />
            </main>
        </div>
    );
};

export default UserLayout;
