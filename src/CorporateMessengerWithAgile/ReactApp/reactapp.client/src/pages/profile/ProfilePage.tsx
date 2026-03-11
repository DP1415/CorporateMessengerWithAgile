// src/pages/profile/ProfilePage.tsx
import React from 'react';
import { useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../../layouts';
import type { AuthController } from '../../controllers';

interface ProfilePageProps {
    onLogout: (authController: AuthController) => void;
}

const ProfilePage: React.FC<ProfilePageProps> = ({ onLogout }) => {
    const { controller, currentUser } = useOutletContext<UserLayoutContext>();

    return (
        <div>
            <h2>Ваш профиль</h2>
            <div>
                <p>Имя пользователя: {currentUser.username}</p>
                <p>Email: {currentUser.email}</p>
                <p>Роль: {currentUser.role}</p>
                <p>Телефон: {currentUser.phoneNumber || 'Не указан'}</p>
            </div>
            <button onClick={() => onLogout(controller.Auth)}>Выйти</button>
        </div>
    );
};

export default ProfilePage;
