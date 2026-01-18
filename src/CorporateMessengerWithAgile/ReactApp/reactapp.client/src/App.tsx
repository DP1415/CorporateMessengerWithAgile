// src/App.tsx
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { UserDto } from './models/entity/UserDto';
import { WelcomePage, LoginForm, RegisterForm, UserLayout, ProtectedRoute } from './components';
import ProfilePage from './components/user/ProfilePage';

const App: React.FC = () => {
    const [authUser, setAuthUser] = useState<{ token: string; user: UserDto } | null>(null);
    const [authChecked, setAuthChecked] = useState(false);
    const [initialUsername, setInitialUsername] = useState<string | null>(null);

    useEffect(() => {
        const token = localStorage.getItem('accessToken');
        const userStr = localStorage.getItem('authUser');
        if (token && userStr) {
            try {
                const user = JSON.parse(userStr) as UserDto;
                setAuthUser({ token, user });
            } catch {
                console.error('Failed to parse stored user data');
                localStorage.removeItem('accessToken');
                localStorage.removeItem('authUser');
            }
        }
        setAuthChecked(true);
    }, []);

    const handleAuthSuccess = (userData: { token: string; user: UserDto }) => {
        setAuthUser(userData);
        localStorage.setItem('accessToken', userData.token);
        localStorage.setItem('authUser', JSON.stringify(userData.user));
    };

    const handleRegisterSuccess = (userData: UserDto) => {
        setInitialUsername(userData.username);
    };

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/welcome" element={<WelcomePage />} />
                    <Route path="/login" element={<LoginForm onSuccess={handleAuthSuccess} initialUsername={initialUsername} />} />
                    <Route path="/register" element={<RegisterForm onSuccess={handleRegisterSuccess} />} />

                    <Route path="/" element={
                        <ProtectedRoute authUser={authUser} authChecked={authChecked} element={<UserLayout authUser={authUser!} />}
                        />}
                    >
                        <Route
                            index
                            element={
                                <div>
                                    <p>Это ваша домашняя страница</p>
                                    <div>
                                        <h3>Информация о пользователе:</h3>
                                        <p>Email: {authUser?.user.email}</p>
                                        <p>Имя пользователя: {authUser?.user.username}</p>
                                        <p>Роль: {authUser?.user.role}</p>
                                        <p>Номер телефона: {authUser?.user.phoneNumber}</p>
                                    </div>
                                    <div>
                                        <p>Здесь будет отображаться персонализированный контент</p>
                                    </div>
                                </div>
                            }
                        />
                        <Route path="profile" element={<ProfilePage />} />
                    </Route>

                    {/* Обработка несуществующих маршрутов */}
                    <Route
                        path="*"
                        element={<NotFoundRedirect authUser={authUser} authChecked={authChecked} />}
                    />
                </Routes>
            </div>
        </Router>
    );
};

// Компонент для редиректа при 404
function NotFoundRedirect({ authUser, authChecked }: {
    authUser: { token: string; user: UserDto } | null;
    authChecked: boolean;
}) {
    if (!authChecked) return <div>Загрузка...</div>;
    return authUser ? <Navigate to="/" replace /> : <Navigate to="/welcome" replace />;
}

export default App;