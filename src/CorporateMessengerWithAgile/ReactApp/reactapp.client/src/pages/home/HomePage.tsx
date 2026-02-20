// src/pages/company/CompanyPage.tsx
import React from 'react';
import { useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../../layouts';

const HomePage: React.FC = () => {
    const { currentUser } = useOutletContext<UserLayoutContext>();

    return (<>
        <p>Домашняя страница</p>
        <p>Email: {currentUser?.email}</p>
        <p>Имя пользователя: {currentUser?.username}</p>
        <p>Роль: {currentUser?.role}</p>
        <p>Номер телефона: {currentUser?.phoneNumber}</p>
    </>);
};

export default HomePage;
