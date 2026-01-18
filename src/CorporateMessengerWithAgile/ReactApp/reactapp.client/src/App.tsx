// src/App.tsx
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { type UserDto, UserDtoSchema } from './models/entity/UserDto';
import { loadFromStorage, saveToStorage } from './utils/storage';
import { WelcomePage, LoginForm, RegisterForm, UserLayout, ProtectedRoute, NotFoundRedirect } from './components';
import ProfilePage from './components/user/ProfilePage';

const App: React.FC = () => {
    const [authUser, setAuthUser] = useState<{ token: string; user: UserDto } | null>(null);
    const [authChecked, setAuthChecked] = useState(false);
    const [initialUsername, setInitialUsername] = useState<string | null>(null);

    useEffect(() => {
        const token = localStorage.getItem('accessToken');
        const user = loadFromStorage('authUser', UserDtoSchema);
        if (token && user) {
            setTimeout(() => {
                setAuthUser({ token, user });
            }, 0);
        }
        setTimeout(() => {
            setAuthChecked(true);
        }, 0);
    }, []);

    const handleAuthSuccess = (userData: { token: string; user: UserDto }) => {
        setAuthUser(userData);
        localStorage.setItem('accessToken', userData.token);
        saveToStorage('authUser', userData.user);
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
                        <ProtectedRoute
                            authUser={authUser}
                            authChecked={authChecked}
                            element={<UserLayout authUser={authUser!} />}
                        />}>
                        <Route
                            index
                            element={
                                <div>
                                    <p>Домашняя страница</p>
                                    <p>Email: {authUser?.user.email}</p>
                                    <p>Имя пользователя: {authUser?.user.username}</p>
                                    <p>Роль: {authUser?.user.role}</p>
                                    <p>Номер телефона: {authUser?.user.phoneNumber}</p>
                                </div>
                            }
                        />
                        <Route path="profile" element={<ProfilePage />} />
                    </Route>

                    <Route path="*" element={<NotFoundRedirect authUser={authUser} authChecked={authChecked} />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;