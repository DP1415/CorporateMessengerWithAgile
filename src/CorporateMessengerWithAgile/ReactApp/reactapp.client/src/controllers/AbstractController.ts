// src/controllers/AbstractController.ts
import { AppError, Result } from "../models";

const API_BASE_URL: string = 'https://localhost:5018/cmwa';

export abstract class AbstractController {
    protected readonly baseUrl: string;
    protected readonly headers: HeadersInit;

    constructor(endpoint: string, headers: HeadersInit = {}) {
        this.baseUrl = API_BASE_URL + endpoint;
        this.headers = {
            'Content-Type': 'application/json',
            ...headers
        };
    }
    private async request(endpoint: string, options: RequestInit = {}): Promise<Result<unknown>> {
        const url = this.baseUrl + endpoint;
        const method = options.method || 'GET';

        console.log(`[API] ${method} -> ${url}`); // ✅ Логируем начало запроса

        const config: RequestInit = {
            ...options,
            headers: {
                ...this.headers,
                ...options.headers
            }
        };

        let response: Response;

        try {
            response = await fetch(url, config);
        } catch (error: unknown) {
            const errorMessage = error instanceof Error ? error.message : 'Ошибка сети';
            console.error(`[API] Network Error at ${url}:`, errorMessage); // ✅ Логируем ошибку сети
            const appError = new AppError('Network.Error', errorMessage, -1);
            return Result.FailureWith(appError);
        }

        if (response.ok) {
            const data = await response.json();
            console.log(`[API] Success ${response.status} <- ${url}`, data); // ✅ Логируем успешный ответ
            return Result.SuccessWith(data);
        }

        const errorBody = await response.json().catch(() => ({}));
        const { code = 'Unknown.Error', message = 'Ошибка при обработке запроса' } = errorBody;
        const error = new AppError(code, message, response.status);

        console.error(`[API] Failed ${response.status} <- ${url}`, errorBody); // ✅ Логируем ошибку сервера
        return Result.FailureWith(error);
    }

    protected get(endpoint: string, headers: HeadersInit = {}): Promise<Result<unknown>> {
        return this.request(
            endpoint,
            {
                method: 'GET',
                headers
            });
    }

    protected post(endpoint: string, body?: unknown, headers: HeadersInit = {}): Promise<Result<unknown>> {
        return this.request(
            endpoint,
            {
                method: 'POST',
                headers,
                body: body != null ? JSON.stringify(body) : undefined
            });
    }

    protected put(endpoint: string, body?: unknown, headers: HeadersInit = {}): Promise<Result<unknown>> {
        return this.request(
            endpoint,
            {
                method: 'PUT',
                headers,
                body: body != null ? JSON.stringify(body) : undefined
            });
    }

    protected delete(endpoint: string, headers: HeadersInit = {}): Promise<Result<unknown>> {
        return this.request(
            endpoint,
            {
                method: 'DELETE',
                headers
            });
    }
}