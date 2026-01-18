// src/components/UserLayout.tsx
import React from 'react';
import { Outlet, Link } from 'react-router-dom';
import { type UserDto } from '../models/entity/UserDto';
import styles from './UserLayout.module.css';

interface UserLayoutProps {
    authUser: { token: string; user: UserDto };
    onLogout: () => void;
}

export interface UserLayoutContext {
    authUser: { token: string; user: UserDto };
    onLogout: () => void;
}

const UserLayout: React.FC<UserLayoutProps> = ({ authUser, onLogout }) => {
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
                <Outlet context={{ authUser, onLogout }} />
            </main>
        </div>
    );
};

export default UserLayout;
