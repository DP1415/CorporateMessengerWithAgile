// src/components/WelcomePage.tsx
import React from 'react';
import { Link } from 'react-router-dom';

const WelcomePage: React.FC = () => {
    return (
        <div className="welcome-page">
            <h1>Добро пожаловать!</h1>
            <div className="welcome-actions">
                <Link to="/login">Войти</Link>
                <span> или </span>
                <Link to="/register">Зарегистрироваться</Link>
            </div>
        </div>
    );
};

export default WelcomePage;
