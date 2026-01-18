// src/components/UserLayout.tsx
import React from 'react';
import { Outlet, Link } from 'react-router-dom';
import { UserDto } from '../models/entity/UserDto';
import styles from './UserLayout.module.css';

interface UserHomePageProps {
    authUser: { token: string; user: UserDto };
}

const UserLayout: React.FC<UserHomePageProps> = ({ authUser }) => {
    return (
        <div className={styles.userHomeLayout}>
            <aside className={styles.sidebar}>
                <nav>
                    <ul>
                        <li><Link to="/">Главная</Link></li>
                        <li><Link to="/profile">Профиль</Link></li>
                    </ul>
                </nav>
            </aside>

            <main className={styles.mainContent}>
                <Outlet context={{ authUser }} />
            </main>
        </div>
    );
};

export default UserLayout;
