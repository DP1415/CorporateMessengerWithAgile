import React, { useState } from 'react';
import { AuthController } from '../../controllers';
import { AppError, UserDto } from '../../models';
import { useNavigate } from 'react-router-dom';


interface LoginFormProps {
    onSuccess: (userData: { token: string; user: UserDto }) => void;
    initialUsername: string | null;
}

const LoginForm: React.FC<LoginFormProps> = ({ onSuccess, initialUsername }) => {
    const [username, setUsername] = useState(initialUsername || '');
    const [password, setPassword] = useState('');
    const [error, setError] = useState<AppError | null>(null);
    const authController = new AuthController();
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        const result = await authController.Login({ username, password });

        if (result.isSuccess) {
            onSuccess(result.value);
            navigate(`/${result.value.user.username}`);
        } else {
            setError(result.error);
        }
    };

    return (
        <div className="auth-form">
            <h2>Вход в профиль</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="username">Имя пользователя:</label>
                    <input
                        type="text"
                        id="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Пароль:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Войти</button>
                {error && (
                    <div className="error-message" role="alert">
                        {error.message}
                    </div>
                )}
            </form>
        </div>
    );
};

export default LoginForm;
