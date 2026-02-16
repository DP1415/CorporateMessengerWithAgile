// src/controllers/AuthController.ts
import { AbstractController } from './AbstractController';
import { type UserSummaryDto, UserSummaryDtoSchema } from '../models';
import { Result, AppError } from '../models';
import { validateWithSchema } from '../utils/validation';

const LOCAL_STORAGE_NAME = {
    accessToken: 'accessToken',
    refreshToken: 'refreshToken',
    currentUserId: 'currentUserId'
}

export class AuthController extends AbstractController {
    constructor() { super('/Auth'); }

    async Register(username: string, email: string, password: string): Promise<Result<UserSummaryDto>> {
        const result = await this.request('POST', '/Register', { username: username, password: password, email: email });
        if (result.isFailure)
            return result as Result<UserSummaryDto>;
        return validateWithSchema(UserSummaryDtoSchema, result.value);
    }

    async Login(username: string, password: string): Promise<Result<UserSummaryDto>> {
        const body = { username: username, password: password };
        const result = await this.request('POST', '/Login', body);
        if (result.isFailure)
            return result as Result<UserSummaryDto>;
        if (typeof result.value !== 'object' || result.value === null)
            return Result.FailureWith(new AppError('Validation.Error', 'Не удалось обработать ответ', -1));

        const valueObj = result.value as Record<string, unknown>;
        if (typeof valueObj.accessToken !== 'string')
            return Result.FailureWith(new AppError('Validation.Error', 'Отсутствующий или недействительный токен доступа', -1));
        if (typeof valueObj.refreshToken !== 'string')
            return Result.FailureWith(new AppError('Validation.Error', 'Отсутствующий или недействительный/недопустимый токен обновления', -1));

        const userResult = validateWithSchema(UserSummaryDtoSchema, valueObj.user);
        if (userResult.isFailure)
            return Result.FailureWith<UserSummaryDto>(userResult.error);

        localStorage.setItem(LOCAL_STORAGE_NAME.accessToken, valueObj.accessToken);
        localStorage.setItem(LOCAL_STORAGE_NAME.refreshToken, valueObj.refreshToken);
        localStorage.setItem(LOCAL_STORAGE_NAME.currentUserId, userResult.value.id);

        return Result.SuccessWith(userResult.value);
    }

    async UpdateRefreshToken(): Promise<Result> {
        const refreshToken = localStorage.getItem(LOCAL_STORAGE_NAME.refreshToken);
        const currentUserId = localStorage.getItem(LOCAL_STORAGE_NAME.currentUserId);
        if (!refreshToken)
            return Result.FailureWith(new AppError('Auth.Error', 'Нет токена обновления в localStorage', -1));
        if (!currentUserId)
            return Result.FailureWith(new AppError('Auth.Error', 'UserId не найден для обновления токена', -1));

        const body = { OldRefreshToken: refreshToken, UserId: currentUserId };
        const result = await this.request('POST', '/Refresh', body);
        if (result.isFailure) return result as Result;

        const valueObj = result.value as Record<string, unknown>;
        if (typeof valueObj.accessToken !== 'string')
            return Result.FailureWith(new AppError('Validation.Error', 'Отсутствующий или недействительный токен доступа', -1));
        if (typeof valueObj.refreshToken !== 'string')
            return Result.FailureWith(new AppError('Validation.Error', 'Отсутствующий или недействительный/недопустимый токен обновления', -1));

        localStorage.setItem(LOCAL_STORAGE_NAME.refreshToken, valueObj.refreshToken);
        localStorage.setItem(LOCAL_STORAGE_NAME.accessToken, valueObj.accessToken);

        return result as Result;
    }

    async Logout(): Promise<Result> {
        const refreshToken = localStorage.getItem(LOCAL_STORAGE_NAME.refreshToken);
        const currentUserId = localStorage.getItem(LOCAL_STORAGE_NAME.currentUserId);
        if (!refreshToken)
            return Result.FailureWith(new AppError('Auth.Error', 'Нет токена обновления в localStorage', -1));
        if (!currentUserId)
            return Result.FailureWith(new AppError('Auth.Error', 'UserId не найден для обновления токена', -1));

        const body = { OldRefreshToken: refreshToken, UserId: currentUserId };
        const result = await this.request('POST', '/Refresh', body);
        if (result.isFailure) return result as Result;

        localStorage.removeItem(LOCAL_STORAGE_NAME.accessToken);
        localStorage.removeItem(LOCAL_STORAGE_NAME.refreshToken);
        localStorage.removeItem(LOCAL_STORAGE_NAME.currentUserId);

        return result as Result;
    }
}