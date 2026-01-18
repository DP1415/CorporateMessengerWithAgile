// src/controllers/AuthenticatedController.ts
import type { Result } from '../models';
import { AbstractController, type HttpMethod } from './AbstractController';

export abstract class AuthenticatedController extends AbstractController {
    private getAuthHeaders(): HeadersInit {
        const token = localStorage.getItem('accessToken');
        if (token) {
            return { 'Authorization': `Bearer ${token}` };
        }
        return {};
    }

    protected override async request(
        method: HttpMethod,
        endpoint: string,
        body?: unknown,
        headers: HeadersInit = {}
    ): Promise<Result<unknown>> {
        const authHeaders = this.getAuthHeaders();
        return super.request(method, endpoint, body, {
            ...authHeaders,
            ...headers
        });
    }
}