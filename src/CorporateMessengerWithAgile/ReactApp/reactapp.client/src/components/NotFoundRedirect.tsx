// src/components/NotFoundRedirect.tsx
import { Navigate } from 'react-router-dom';
import { UserDto } from '../models/entity/UserDto';

interface NotFoundRedirectProps {
    authUser: { token: string; user: UserDto } | null;
    authChecked: boolean;
}

const NotFoundRedirect: React.FC<NotFoundRedirectProps> = ({ authUser, authChecked }) => {
    if (!authChecked) { return <div>Загрузка...</div>; }
    if (authUser) { return <Navigate to="/" replace />; }
    return <Navigate to="/welcome" replace />;
};

export default NotFoundRedirect;