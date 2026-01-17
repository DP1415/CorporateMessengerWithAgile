// src/App.tsx
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { UserDto } from './models/entity/UserDto';
import { WelcomePage, LoginForm, RegisterForm, UserHomePage, ProtectedRoute } from './components';

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
                    <Route path="/" element={<WelcomePage />} />
                    <Route path="/login" element={<LoginForm onSuccess={handleAuthSuccess} initialUsername={initialUsername} />} />
                    <Route path="/register" element={<RegisterForm onSuccess={handleRegisterSuccess} />} />
                    <Route
                        path="/:username"
                        element={
                            <ProtectedRoute
                                authUser={authUser}
                                authChecked={authChecked}
                                element={<UserHomePage authUser={authUser!} />}
                            />
                        }
                    />
                    <Route path="*" element={<Navigate to="/" replace />} />
                </Routes>
            </div>
        </Router >
    );
};

export default App;
