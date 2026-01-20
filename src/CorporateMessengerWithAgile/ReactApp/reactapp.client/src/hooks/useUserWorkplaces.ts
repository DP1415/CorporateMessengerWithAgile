// src/hooks/useUserWorkplaces.ts
import { useState, useEffect } from 'react';
import { UserController } from '../controllers/UserController';
import type { WorkplaceDto, Result } from '../models';
import { AppError } from '../models';

// Глобальный кэш на уровне модуля (можно заменить на Context или React Query позже)
let cachedWorkplaces: WorkplaceDto[] | null = null;

export const useUserWorkplaces = (userId: string) => {
    const [workplaces, setWorkplaces] = useState<WorkplaceDto[] | null>(cachedWorkplaces);
    const [loading, setLoading] = useState(!cachedWorkplaces);
    const [error, setError] = useState<AppError | null>(null);

    useEffect(() => {
        if (cachedWorkplaces) {
            setWorkplaces(cachedWorkplaces);
            setLoading(false);
            return;
        }

        const fetchCompanies = async () => {
            try {
                const controller = new UserController();
                const result: Result<WorkplaceDto[]> = await controller.getWorkplaces(userId);
                if (result.isFailure) setError(result.error || new AppError('LoadWorkplaces.Error', 'Не удалось загрузить компании', -1));
                else {
                    cachedWorkplaces = result.value;
                    setWorkplaces(result.value);
                    setError(null);
                }
            }
            catch (err) {
                setError(err instanceof Error ? new AppError('Network.Error', err.message, -1) : new AppError('Network.Error', 'Ошибка сети', -1));
            }
            finally {
                setLoading(false);
            }
        };

        fetchCompanies();
    }, [userId]);

    return { workplaces, loading, error };
};
