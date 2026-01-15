// src/components/ProtectedRoute.tsx
import { Navigate, useParams } from 'react-router-dom';
import type { ReactNode } from 'react';
import { UserDto } from '../models/entity/UserDto';

interface ProtectedRouteProps {
    element: ReactNode;
    authUser: { token: string; user: UserDto } | null;
    authChecked: boolean;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ element, authUser, authChecked }) => {
    const { username } = useParams<{ username: string }>();
    if (!authChecked) { return <div>Проверка сессии...</div>; }
    if (!authUser) { return <Navigate to="/login" replace />; }
    if (username !== authUser.user.username) { return <Navigate to={`/${authUser.user.username}`} replace />; }
    return element;
};

export default ProtectedRoute;