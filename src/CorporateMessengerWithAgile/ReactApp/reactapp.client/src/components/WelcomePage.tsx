// src/components/WelcomePage.tsx
import React from 'react';
import { Link } from 'react-router-dom';

const WelcomePage: React.FC = () => {
    return (
        <div>
            <h1>Добро пожаловать!</h1>
            <Link to="/login">Войти</Link>
            <span> или </span>
            <Link to="/register">Зарегистрироваться</Link>
        </div>
    );
};

export default WelcomePage;
