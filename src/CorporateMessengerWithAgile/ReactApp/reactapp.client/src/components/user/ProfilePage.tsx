// src/components/user/ProfilePage.tsx
import React from 'react';
import { useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';

const ProfilePage: React.FC = () => {
    const { authUser, onLogout } = useOutletContext<UserLayoutContext>();
    const { user } = authUser;

    return (
        <div>
            <h2>Ваш профиль</h2>
            <div>
                <p><strong>Имя пользователя:</strong> {user.username}</p>
                <p><strong>Email:</strong> {user.email}</p>
                <p><strong>Роль:</strong> {user.role}</p>
                <p><strong>Телефон:</strong> {user.phoneNumber || 'Не указан'}</p>
            </div>

            <button onClick={onLogout}>
                Выйти
            </button>
        </div>
    );
};

export default ProfilePage;