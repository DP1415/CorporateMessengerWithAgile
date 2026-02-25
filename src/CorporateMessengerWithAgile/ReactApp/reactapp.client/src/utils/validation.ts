// src/utils/validation.ts
import { z } from 'zod';
import { Result, AppError } from '../models';

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

export function convertToArray<T>(schema: z.ZodType<T>, arrayData: unknown): Result<T[]> {
    if (!Array.isArray(arrayData)) return Result.FailureWith(new AppError('Validation.Error', 'Полученные данные не являются массивом', -1));

    const validatedData: T[] = [];
    for (const item of arrayData) {
        const validatedItem = validateWithSchema(schema, item);
        if (validatedItem.isFailure) return validatedItem as Result<T[]>;
        validatedData.push(validatedItem.value);
    }
    return Result.SuccessWith(validatedData);
}
