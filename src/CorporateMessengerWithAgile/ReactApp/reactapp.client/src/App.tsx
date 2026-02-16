// src/App.tsx
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { type UserSummaryDto, UserSummaryDtoSchema } from './models';
import { loadFromStorage, saveToStorage } from './utils/storage';
import { AuthController, UserController } from './controllers';
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
    const [currentUser, setCurrentUser] = useState<UserSummaryDto | null>(null);
    const [authChecked, setAuthChecked] = useState(false);
    const [initialUsername, setInitialUsername] = useState<string | null>(null);

    useEffect(() => {
        const user = loadFromStorage('currentUser', UserSummaryDtoSchema);
        if (user) {
            setTimeout(() => {
                setCurrentUser(user);
            }, 0);
        }
        setTimeout(() => {
            setAuthChecked(true);
        }, 0);
    }, []);

    const handleAuthSuccess = (userData: UserSummaryDto) => {
        setCurrentUser(userData);
        saveToStorage('currentUser', userData);
    };

    const handleRegisterSuccess = (userData: UserSummaryDto) => { setInitialUsername(userData.username); };

    const handleLogout = (userController: UserController) => {
        //wip 
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

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/welcome" element={<WelcomePage />} />
                    <Route path="/login" element={<LoginForm authController={authController} onSuccess={handleAuthSuccess} initialUsername={initialUsername} />} />
                    <Route path="/register" element={<RegisterForm authController={authController} onSuccess={handleRegisterSuccess} />} />

                    <Route path="/" element={
                        <ProtectedRoute currentUser={currentUser} authChecked={authChecked}>
                            <UserLayout userController={userController} currentUser={currentUser!} />
                        </ProtectedRoute>
                    }>
                        <Route index element={homeElement} />
                        <Route path="/profile" element={<ProfilePage onLogout={handleLogout} />} />
                        <Route path="/company/:companyTitle" element={<CompanyPage />} />
                        <Route path="/company/:companyTitle/project/:projectTitle" element={<ProjectPage />} />
                        <Route path="/company/:companyTitle/project/:projectTitle/team/:teamTitle" element={<TeamPage />} />

                    </Route>

                    <Route path="*" element={<NotFoundRedirect currentUser={currentUser} authChecked={authChecked} />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
