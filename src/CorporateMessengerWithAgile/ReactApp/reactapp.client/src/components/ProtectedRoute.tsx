// src/components/ProtectedRoute.tsx
import React from 'react';
import { Navigate } from 'react-router-dom';
import type { ReactNode } from 'react';
import type { UserSummaryDto } from '../models';

interface ProtectedRouteProps {
    children: ReactNode;
    currentUser: UserSummaryDto | null;
    authChecked: boolean;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ children, currentUser, authChecked }) => {
    if (!authChecked) {
        return <div>Проверка сессии...</div>;
    }
    if (!currentUser) {
        return <Navigate to="/login" replace />;
    }
    return children;
};

export default ProtectedRoute;
