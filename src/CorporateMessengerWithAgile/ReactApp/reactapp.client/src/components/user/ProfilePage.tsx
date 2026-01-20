// src/components/user/ProfilePage.tsx
import React from 'react';
import { useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';

interface ProfilePageProps {
    onLogout: () => void;
}

const ProfilePage: React.FC<ProfilePageProps> = ({ onLogout }) => {
    const { authUser } = useOutletContext<UserLayoutContext>();
    const { user } = authUser;

    return (
        <div>
            <h2>Ваш профиль</h2>
            <div>
                <p>Имя пользователя: {user.username}</p>
                <p>Email: {user.email}</p>
                <p>Роль: {user.role}</p>
                <p>Телефон: {user.phoneNumber || 'Не указан'}</p>
            </div>
            <button onClick={onLogout}>Выйти</button>
        </div>
    );
};

export default ProfilePage;