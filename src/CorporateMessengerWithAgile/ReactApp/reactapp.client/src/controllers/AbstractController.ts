// src/controllers/AbstractController.ts
import { AppError, Result } from '../models';

const API_BASE_URL = 'https://localhost:5018/cmwa';
export type HttpMethod = 'GET' | 'POST' | 'PUT' | 'DELETE' | 'HEAD';

let requestCounter = 0;

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
        const requestId = ++requestCounter;
        const url = this.baseUrl + endpoint;

        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        const log = (...args: any[]) => console.log(`[API #${requestId}]`, ...args);
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        const logError = (...args: any[]) => console.error(`[API #${requestId}]`, ...args);

        const config: RequestInit = {
            method,
            headers: {
                ...this.headers,
                ...headers
            }
        };

        log(`${method} -> ${url}`, { config: config });

        if (body !== undefined) {
            config.body = JSON.stringify(body);
        }

        let response: Response;

        try {
            response = await fetch(url, config);
        } catch (error: unknown) {
            const errorMessage = error instanceof Error ? error.message : 'Ошибка сети';
            logError(`Network Error at ${url}:`, errorMessage);
            return Result.FailureWith(new AppError('Network.Error', errorMessage, -1));
        }

        if (response.ok) {
            const data = await response.json();
            log(`Success ${response.status} <- ${url}`, data);
            return Result.SuccessWith(data);
        }

        const errorBody = await response.json().catch(() => ({}));
        const { code = 'Unknown.Error', message = 'Ошибка при обработке запроса' } = errorBody;
        const error = new AppError(code, message, response.status);

        logError(`Failed ${response.status} <- ${url}`, errorBody);
        return Result.FailureWith(error);
    }
}