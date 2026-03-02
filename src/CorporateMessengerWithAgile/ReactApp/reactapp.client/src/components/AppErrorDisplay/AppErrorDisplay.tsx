// src/components/ErrorDisplay/AppErrorDisplay.ts
import { AppError } from '../../models/result/AppError';
import styles from './AppErrorDisplay.module.css';

interface AppErrorDisplayProps {
    error: AppError;
}

export const AppErrorDisplay = ({ error }: AppErrorDisplayProps) => {
    return (
        <div className={styles.errorСontainer}>
            <span className={styles.errorMessage}>{error.message}</span>
            <span className={styles.errorСode}>{error.code}</span>
            <span className={styles.errorStatus}>{error.statusCode}</span>
        </div>
    );
};
