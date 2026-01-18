// src/components/auth/RegisterForm.tsx
import React, { useState } from 'react';
import { AuthController } from '../../controllers/AuthController';
import { AppError, type UserDto } from '../../models';
import { useNavigate } from 'react-router-dom';
import styles from './AuthForm.module.css';

interface RegisterFormProps {
    onSuccess: (userData: UserDto) => void;
}

const RegisterForm: React.FC<RegisterFormProps> = ({ onSuccess }) => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState<AppError | null>(null);
    const authController = new AuthController();
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        const result = await authController.Register({ username, email, password });

        if (result.isSuccess) {
            onSuccess(result.value);
            navigate('/login');
        } else {
            setError(result.error);
        }
    };
    return (
        <div className={styles.authForm}>
            <h2>Регистрация</h2>
            <form onSubmit={handleSubmit}>
                <div className={styles.authFormGroup}>
                    <label htmlFor="reg-username">Имя пользователя:</label>
                    <input
                        type="text"
                        id="reg-username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                </div>
                <div className={styles.authFormGroup}>
                    <label htmlFor="reg-email">Email:</label>
                    <input
                        type="email"
                        id="reg-email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div className={styles.authFormGroup}>
                    <label htmlFor="reg-password">Пароль:</label>
                    <input
                        type="password"
                        id="reg-password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Зарегистрироваться</button>
                {error && (
                    <div className={styles.errorMessage} role="alert">
                        {error.message}
                    </div>
                )}
            </form>
        </div>
    );
};

export default RegisterForm;
