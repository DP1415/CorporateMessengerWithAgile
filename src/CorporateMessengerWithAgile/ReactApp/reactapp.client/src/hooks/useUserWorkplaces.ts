// src/hooks/useUserWorkplaces.ts
import { useState, useEffect } from 'react';
import { UserController } from '../controllers/UserController';
import type { WorkplaceDto, Result } from '../models';

// Глобальный кэш на уровне модуля (можно заменить на Context или React Query позже)
let cachedWorkplaces: WorkplaceDto[] | null = null;

export const useUserWorkplaces = (userId: string) => {
    const [workplaces, setWorkplaces] = useState<WorkplaceDto[] | null>(cachedWorkplaces);
    const [loading, setLoading] = useState(!cachedWorkplaces);
    const [error, setError] = useState<string | null>(null);

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
                if (result.isFailure) setError(result.error?.message || 'Не удалось загрузить компании');
                else {
                    cachedWorkplaces = result.value;
                    setWorkplaces(result.value);
                    setError(null);
                }
            }
            catch (err) {
                setError(err instanceof Error ? err.message : 'Ошибка сети');
            }
            finally {
                setLoading(false);
            }
        };

        fetchCompanies();
    }, [userId]);

    return { workplaces, loading, error };
};