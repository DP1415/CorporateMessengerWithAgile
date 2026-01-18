// src/components/ProtectedRoute.tsx
import React from 'react';
import { Navigate } from 'react-router-dom';
import type { ReactNode } from 'react';
import { UserDto } from '../models/entity/UserDto';

interface ProtectedRouteProps {
    element: ReactNode;
    authUser: { token: string; user: UserDto } | null;
    authChecked: boolean;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ element, authUser, authChecked }) => {
    if (!authChecked) { return <div>Проверка сессии...</div>; }
    if (!authUser) { return <Navigate to="/login" replace />; }
    return element;
};

export default ProtectedRoute;
