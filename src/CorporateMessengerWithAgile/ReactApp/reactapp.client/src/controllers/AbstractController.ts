// src/controllers/AbstractController.ts
import axios from 'axios';
import type { AxiosRequestConfig, AxiosResponse } from 'axios';
import { AppError, Result } from '../models';

const API_BASE_URL = 'https://localhost:5018/cmwa';
export type HttpMethod = 'GET' | 'POST' | 'PUT' | 'DELETE' | 'HEAD';

let requestCounter = 0;

export class AbstractController {
    protected readonly baseUrl: string;
    protected readonly defaultHeaders: Record<string, string>;

    constructor(endpoint: string, defaultHeaders: Record<string, string> = {}) {
        this.baseUrl = API_BASE_URL + endpoint;
        this.defaultHeaders = {
            'Content-Type': 'application/json',
            ...defaultHeaders
        };
    }

    protected async request(
        method: HttpMethod,
        endpoint: string,
        body?: unknown,
        headers: Record<string, string> = {}
    ): Promise<Result<unknown>> {
        const requestId = ++requestCounter;
        const url = this.baseUrl + endpoint;

        const log = (...args: unknown[]) => console.log(`[API #${requestId}]`, ...args);
        const logError = (...args: unknown[]) => console.error(`[API #${requestId}]`, ...args);

        const config: AxiosRequestConfig = {
            method: method.toLowerCase(),
            url,
            headers: {
                ...this.defaultHeaders,
                ...headers
            },
            data: body
        };

        log(`${method} -> ${url}`, { config });

        try {
            const response: AxiosResponse = await axios(config);

            log(`Success ${response.status} <- ${url}`, response.data);
            return Result.SuccessWith(response.data);
        } catch (error: unknown) {
            if (error instanceof AppError) {
                logError(`Failed ${error.statusCode} <- ${url} AppError`, error);
                return Result.FailureWith(error);
            }
            else if (axios.isAxiosError(error)) {
                const status = error.response?.status || -1;
                const errorData = error.response?.data || {};
                const { code = 'Unknown.Error', message = 'Ошибка при обработке запроса' } = errorData;

                const appError = new AppError(code, message, status);

                logError(`Failed ${status} <- ${url} AxiosError`, { errorData: errorData, error: error });
                return Result.FailureWith(appError);
            } else {
                const errorMessage = error instanceof Error ? error.message : 'Ошибка при обработке запроса';
                logError(`Failed ### <- ${url}`, { errorMessage: errorMessage, error: error });
                return Result.FailureWith(new AppError('Unknown.Error', errorMessage, -1));
            }
        }
    }
}