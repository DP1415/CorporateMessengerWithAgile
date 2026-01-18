// src/controllers/AbstractController.ts
import { AppError, Result } from '../models';

const API_BASE_URL = 'https://localhost:5018/cmwa';
export type HttpMethod = 'GET' | 'POST' | 'PUT' | 'DELETE' | 'HEAD';

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

    protected async request(
        method: HttpMethod,
        endpoint: string,
        body?: unknown,
        headers: HeadersInit = {}
    ): Promise<Result<unknown>> {
        const url = this.baseUrl + endpoint;
        console.log(`[API] ${method} -> ${url}`);

        const config: RequestInit = {
            method,
            headers: {
                ...this.headers,
                ...headers
            }
        };

        if (body !== undefined) {
            config.body = JSON.stringify(body);
        }

        let response: Response;

        try {
            response = await fetch(url, config);
        } catch (error: unknown) {
            const errorMessage = error instanceof Error ? error.message : 'Ошибка сети';
            console.error(`[API] Network Error at ${url}:`, errorMessage);
            const appError = new AppError('Network.Error', errorMessage, -1);
            return Result.FailureWith(appError);
        }

        if (response.ok) {
            const data = await response.json();
            console.log(`[API] Success ${response.status} <- ${url}`, data);
            return Result.SuccessWith(data);
        }

        const errorBody = await response.json().catch(() => ({}));
        const { code = 'Unknown.Error', message = 'Ошибка при обработке запроса' } = errorBody;
        const error = new AppError(code, message, response.status);

        console.error(`[API] Failed ${response.status} <- ${url}`, errorBody);
        return Result.FailureWith(error);
    }
}