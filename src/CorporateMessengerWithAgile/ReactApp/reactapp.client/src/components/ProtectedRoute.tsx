// src/components/ProtectedRoute.tsx
import React from 'react';
import { Navigate } from 'react-router-dom';
import type { ReactNode } from 'react';
import { type UserDto } from '../models/entity/UserDto';

interface ProtectedRouteProps {
    children: ReactNode;
    authUser: { token: string; user: UserDto } | null;
    authChecked: boolean;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ children, authUser, authChecked }) => {
    if (!authChecked) {
        return <div>Проверка сессии...</div>;
    }
    if (!authUser) {
        return <Navigate to="/login" replace />;
    }
    return <>{children}</>;
};

export default ProtectedRoute;