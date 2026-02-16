// src/components/NotFoundRedirect.tsx
import React from 'react';
import { Navigate } from 'react-router-dom';
import type { UserSummaryDto } from '../models';

interface NotFoundRedirectProps {
    currentUser: UserSummaryDto | null;
    authChecked: boolean;
}

const NotFoundRedirect: React.FC<NotFoundRedirectProps> = ({ currentUser, authChecked }) => {
    if (!authChecked) {
        return <div>Загрузка...</div>;
    }
    if (currentUser) {
        return <Navigate to="/" replace />;
    }
    return <Navigate to="/welcome" replace />;
};

export default NotFoundRedirect;
