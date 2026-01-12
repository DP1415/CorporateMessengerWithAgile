import { Result } from "../models/result/ResultGeneric";
import { Error as AppError } from "../models/result/Error";

const API_BASE_URL: string = 'https://localhost:5018/cmwa';

export abstract class AbstractController {
    protected readonly baseUrl: string;
    protected readonly headers: HeadersInit;

    constructor(endpoint: string, headers: HeadersInit = {}) {
        this.baseUrl = new URL(endpoint, API_BASE_URL).toString();
        this.headers = {
            'Content-Type': 'application/json',
            ...headers
        };
    }

    protected async request<T>(endpoint: string, options: RequestInit = {}): Promise<Result<T>> {
        const url = new URL(endpoint, this.baseUrl).toString();
        const config: RequestInit = {
            ...options,
            headers: {
                ...this.headers,
                ...options.headers
            }
        };
        let result: Result<T>;
        try {
            const response = await fetch(url, config);
            if (response.ok) {
                if (response.status === 204) result = Result.success(undefined as T);
                else {
                    const data: T = await response.json();
                    result = Result.success(data);
                }
            }
            else {
                const errorBody = await response.json().catch(() => ({}));
                const { code = 'Unknown.Error', message = 'Произошла неизвестная ошибка' } = errorBody;
                const error = new AppError(code, message, response.status);
                result = Result.failure<T>(error);
            }
        } catch (error: unknown) {
            const errorMessage = error instanceof Error ? error.message : 'Произошла ошибка сети';
            const appError = new AppError('Network.Error', errorMessage, 0);
            result = Result.failure<T>(appError);
        }
        if (result.isFailure) console.error(result);
        else console.log(result);
        return result;
    }

    protected get<T>(endpoint: string, headers: HeadersInit = {}): Promise<Result<T>> {
        return this.request<T>(endpoint, { method: 'GET', headers });
    }

    protected post<T>(endpoint: string, body?: unknown, headers: HeadersInit = {}): Promise<Result<T>> {
        return this.request<T>(endpoint, {
            method: 'POST',
            headers,
            body: body != null ? JSON.stringify(body) : undefined
        });
    }

    protected put<T>(endpoint: string, body?: unknown, headers: HeadersInit = {}): Promise<Result<T>> {
        return this.request<T>(endpoint, {
            method: 'PUT',
            headers,
            body: body != null ? JSON.stringify(body) : undefined
        });
    }

    protected delete<T>(endpoint: string, headers: HeadersInit = {}): Promise<Result<T>> {
        return this.request<T>(endpoint, { method: 'DELETE', headers });
    }
}
