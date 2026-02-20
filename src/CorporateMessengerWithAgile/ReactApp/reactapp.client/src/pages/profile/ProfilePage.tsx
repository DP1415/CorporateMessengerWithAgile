// src/pages/profile/ProfilePage.tsx
import React from 'react';
import { useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../../layouts';
import type { UserController } from '../../controllers';

interface ProfilePageProps {
    onLogout: (userController: UserController) => void;
}

const ProfilePage: React.FC<ProfilePageProps> = ({ onLogout }) => {
    const { userController, currentUser } = useOutletContext<UserLayoutContext>();

    return (
        <div>
            <h2>Ваш профиль</h2>
            <div>
                <p>Имя пользователя: {currentUser.username}</p>
                <p>Email: {currentUser.email}</p>
                <p>Роль: {currentUser.role}</p>
                <p>Телефон: {currentUser.phoneNumber || 'Не указан'}</p>
            </div>
            <button onClick={() => onLogout(userController)}>Выйти</button>
        </div>
    );
};

export default ProfilePage;
