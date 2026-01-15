import React from 'react';
import { UserDto } from '../models/entity/UserDto';

interface UserHomePageProps {
    authUser: { token: string; user: UserDto };
}

const UserHomePage: React.FC<UserHomePageProps> = ({ authUser }) => {
    const { user } = authUser;

    return (
        <div className="user-home-page">
            <h1>Добро пожаловать, {user.username}!</h1>
            <p>Это ваша домашняя страница</p>
            <div className="user-info">
                <h3>Информация о пользователе:</h3>
                <p>Email: {user.email}</p>
                <p>Имя пользователя: {user.username}</p>
                <p>Роль: {user.role}</p>
                <p>Номер телефона: {user.phoneNumber}</p>
            </div>
            <div className="user-content">
                <p>Здесь будет отображаться персонализированный контент</p>
                <p>для пользователя {user.username}</p>
            </div>
        </div>
    );
};

export default UserHomePage;