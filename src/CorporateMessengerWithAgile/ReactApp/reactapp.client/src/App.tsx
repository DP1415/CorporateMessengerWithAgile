// src/App.tsx
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { type UserSummaryDto, UserSummaryDtoSchema } from './models';
import { loadFromStorage, saveToStorage } from './utils/storage';
import {
    WelcomePage,
    LoginForm,
    RegisterForm,
    ProtectedRoute,
    UserLayout,
    ProfilePage,
    CompanyPage,
    NotFoundRedirect,
    ProjectPage,
    TeamPage
} from './components';

const App: React.FC = () => {
    const [authUser, setAuthUser] = useState<{ token: string; user: UserSummaryDto } | null>(null);
    const [authChecked, setAuthChecked] = useState(false);
    const [initialUsername, setInitialUsername] = useState<string | null>(null);

    useEffect(() => {
        const token = localStorage.getItem('accessToken');
        const user = loadFromStorage('authUser', UserSummaryDtoSchema);
        if (token && user) {
            setTimeout(() => {
                setAuthUser({ token, user });
            }, 0);
        }
        setTimeout(() => {
            setAuthChecked(true);
        }, 0);
    }, []);

    const handleAuthSuccess = (userData: { token: string; user: UserSummaryDto }) => {
        setAuthUser(userData);
        localStorage.setItem('accessToken', userData.token);
        saveToStorage('authUser', userData.user);
    };

    const handleRegisterSuccess = (userData: UserSummaryDto) => {
        setInitialUsername(userData.username);
    };

    const handleLogout = () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('authUser');
        setAuthUser(null);
    };

    const homeElement = (
        <div>
            <p>Домашняя страница</p>
            <p>Email: {authUser?.user.email}</p>
            <p>Имя пользователя: {authUser?.user.username}</p>
            <p>Роль: {authUser?.user.role}</p>
            <p>Номер телефона: {authUser?.user.phoneNumber}</p>
        </div>
    )

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/welcome" element={<WelcomePage />} />
                    <Route path="/login" element={<LoginForm onSuccess={handleAuthSuccess} initialUsername={initialUsername} />} />
                    <Route path="/register" element={<RegisterForm onSuccess={handleRegisterSuccess} />} />

                    <Route path="/" element={
                        <ProtectedRoute authUser={authUser} authChecked={authChecked}>
                            <UserLayout authUser={authUser!} />
                        </ProtectedRoute>
                    }>
                        <Route index element={homeElement} />
                        <Route path="/profile" element={<ProfilePage onLogout={handleLogout} />} />
                        <Route path="/company/:companyTitle" element={<CompanyPage />} />
                        <Route path="/company/:companyTitle/project/:projectTitle" element={<ProjectPage />} />
                        <Route path="/company/:companyTitle/project/:projectTitle/team/:teamTitle" element={<TeamPage />} />

                    </Route>

                    <Route path="*" element={<NotFoundRedirect authUser={authUser} authChecked={authChecked} />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
