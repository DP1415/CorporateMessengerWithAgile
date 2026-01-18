// src/utils/validation.ts
import { z } from 'zod';
import { Result, AppError } from '../models';

/**
 * Валидирует данные по Zod-схеме и возвращает Result<T>
 */
export function validateWithSchema<T>(schema: z.ZodType<T>, data: unknown): Result<T> {
    const parsed = schema.safeParse(data);
    if (parsed.success) {
        return Result.SuccessWith(parsed.data);
    } else {
        const errors = parsed.error.issues.map(e => `${e.path.join('.')}: ${e.message}`).join('; ');
        const error = new AppError('Validation.Error', `Validation failed: ${errors}`, -1);
        return Result.FailureWith(error);
    }
}
