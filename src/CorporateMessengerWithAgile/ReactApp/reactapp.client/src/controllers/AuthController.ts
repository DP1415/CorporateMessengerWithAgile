import { AbstractController } from './AbstractController';
import { Result } from '../models/result/ResultGeneric';
import { UserDto } from '../models/entity/UserDto';

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
    constructor() {
        super('/Auth');
    }

    async login(credentials: LoginRequest): Promise<Result<LoginResponse>> {
        return this.post<LoginResponse>('/Login', credentials);
    }

    async register(userData: RegisterRequest): Promise<Result<UserDto>> {
        return this.post<UserDto>('/Register', userData);
    }
}
