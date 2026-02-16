// src/controllers/AuthenticatedController.ts
import { Result, AppError } from '../models';
import { AbstractController, type HttpMethod } from './AbstractController';
import { AuthController } from './AuthController';

export abstract class AuthenticatedController extends AbstractController {

    private refreshTokenPromise: Promise<void> | null = null;
    protected authController: AuthController;

    constructor(authController: AuthController, endpoint: string, defaultHeaders: Record<string, string> = {}) {
        super(endpoint, defaultHeaders);
        this.authController = authController
    }

    private getAuthHeaders(): Record<string, string> {
        const accessToken = localStorage.getItem('accessToken');
        return accessToken ? { 'Authorization': `Bearer ${accessToken}` } : {};
    }

    private async refreshAccessToken(): Promise<void> {
        if (this.refreshTokenPromise) return this.refreshTokenPromise;

        this.refreshTokenPromise = (async () => {
            try {
                const result = await this.authController.UpdateRefreshToken();
                if (result.isFailure) {
                    console.error('Не удалось обновить токен', result);
                    throw new Error(result.error.message || 'Token refresh failed (Не удалось обновить токен)');
                }
            } finally {
                this.refreshTokenPromise = null;
            }
        })();

        return this.refreshTokenPromise;
    }

    protected override async request(
        method: HttpMethod,
        endpoint: string,
        body?: unknown,
        headers: Record<string, string> = {}
    ): Promise<Result<unknown>> {
        const firstResult = await super.request(method, endpoint, body, { ...this.getAuthHeaders(), ...headers });
        if (firstResult.isSuccess) return firstResult;

        if (firstResult.error.statusCode !== 401) return firstResult;

        try {
            await (this.refreshTokenPromise || this.refreshAccessToken());
            return super.request(method, endpoint, body, { ...this.getAuthHeaders(), ...headers });
        } catch (error) {
            return Result.FailureWith(new AppError('Auth.RefreshFailed', error instanceof Error ? error.message : 'Сеанс истек. Пожалуйста, войдите в систему еще раз.', -1));
        }
    }
}