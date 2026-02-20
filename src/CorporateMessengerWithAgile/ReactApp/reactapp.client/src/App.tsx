// src/App.tsx
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { type UserSummaryDto, UserSummaryDtoSchema } from './models';
import { loadFromStorage, saveToStorage } from './utils/storage';
import { AuthController, UserController } from './controllers';
import { LoginForm, RegisterForm, } from './forms';
import {
    WelcomePage,
    UserLayout,
    ProfilePage,
    CompanyPage,
    ProjectPage,
    TeamPage
} from './components';

const App: React.FC = () => {
    const [currentUser, setCurrentUser] = useState<UserSummaryDto | null>(null);
    const [loading, setLoading] = useState(true);
    const [initialUsername, setInitialUsername] = useState<string | null>(null);

    useEffect(() => {
        setCurrentUser(loadFromStorage('currentUser', UserSummaryDtoSchema));
        setLoading(false);
    }, []);

    if (loading) return <p>loading...</p>;

    const handleRegisterSuccess = (userData: UserSummaryDto) => {
        setInitialUsername(userData.username);
    };

    const handleLoginSuccess = (userData: UserSummaryDto) => {
        setCurrentUser(userData);
        saveToStorage('currentUser', userData);
    };

    const handleLogout = (userController: UserController) => {
        userController.Logout();
        localStorage.removeItem('currentUser');
        setCurrentUser(null);
    };

    const homeElement = (
        <div>
            <p>Домашняя страница</p>
            <p>Email: {currentUser?.email}</p>
            <p>Имя пользователя: {currentUser?.username}</p>
            <p>Роль: {currentUser?.role}</p>
            <p>Номер телефона: {currentUser?.phoneNumber}</p>
        </div>
    )

    const authController = new AuthController();
    const userController = new UserController(authController);

    const loginForm = <LoginForm authController={authController} onSuccess={handleLoginSuccess} initialUsername={initialUsername} />;
    const registerForm = <RegisterForm authController={authController} onSuccess={handleRegisterSuccess} />;
    const userLayout =
        currentUser
            ? <UserLayout userController={userController} currentUser={currentUser} />
            : <Navigate to="/login" replace />;

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/welcome" element={<WelcomePage />} />
                    <Route path="/login" element={loginForm} />
                    <Route path="/register" element={registerForm} />

                    <Route path="/" element={userLayout}>
                        <Route index element={homeElement} />
                        <Route path="/profile" element={<ProfilePage onLogout={handleLogout} />} />
                        <Route path="/company/:companyTitle" element={<CompanyPage />} />
                        <Route path="/company/:companyTitle/project/:projectTitle" element={<ProjectPage />} />
                        <Route path="/company/:companyTitle/project/:projectTitle/team/:teamTitle" element={<TeamPage />} />
                    </Route>

                    <Route path="*" element={<Navigate to={currentUser ? "/" : "/welcome"} replace />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
