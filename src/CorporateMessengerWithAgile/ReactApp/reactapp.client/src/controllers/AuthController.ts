// src/controllers/AuthController.ts
import { AbstractController } from './AbstractController';
import { type UserDto, UserDtoSchema } from '../models/entity/UserDto';
import { Result, AppError } from '../models';
import { validateWithSchema } from '../utils/validation';

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

    async Login(credentials: LoginRequest): Promise<Result<LoginResponse>> {
        const result = await this.request('POST', '/Login', credentials);
        if (result.isFailure) {
            return result as Result<LoginResponse>;
        }

        const value = result.value;

        if (typeof value !== 'object' || value === null) {
            return Result.FailureWith(new AppError('Validation.Error', 'Response is not an object', -1));
        }

        const valueObj = value as Record<string, unknown>;

        if (typeof valueObj.token !== 'string') {
            return Result.FailureWith(new AppError('Validation.Error', 'Missing or invalid token', -1));
        }

        const userResult = validateWithSchema(UserDtoSchema, valueObj.user);
        if (userResult.isFailure) {
            return Result.FailureWith<LoginResponse>(userResult.error);
        }

        return Result.SuccessWith({ token: valueObj.token, user: userResult.value });
    }

    async Register(userData: RegisterRequest): Promise<Result<UserDto>> {
        const result = await this.request('POST', '/Register', userData);
        if (result.isFailure) {
            return result as Result<UserDto>;
        }

        return validateWithSchema(UserDtoSchema, result.value);
    }
}