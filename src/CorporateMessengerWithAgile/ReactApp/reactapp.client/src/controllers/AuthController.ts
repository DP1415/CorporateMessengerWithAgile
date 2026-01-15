// src/controllers/AuthController.ts
import { AbstractController } from './AbstractController';
import { UserDto, Result } from '../models';

interface LoginRequest {
    username: string;
    password: string;
}

interface RegisterRequest {
    username: string;
    password: string;
    email: string;
}

interface LoginResponse {
    token: string;
    user: UserDto;
}

export class AuthController extends AbstractController {
    constructor() { super('/Auth'); }

    async Login(credentials: LoginRequest): Promise<Result<LoginResponse>> {
        return this.post<LoginResponse>('/Login', credentials);
    }

    async Register(userData: RegisterRequest): Promise<Result<UserDto>> {
        return this.post<UserDto>('/Register', userData);
    }
}
