// src/controllers/UserController.ts
import { AuthenticatedController } from './AuthenticatedController';
import {
    type WorkplaceDto,
    WorkplaceSchema,
    type Guid,
    Result
} from '../models';
import { validateWithSchema } from '../utils/validation';
import { AppError } from '../models/result/AppError';

export class UserController extends AuthenticatedController {
    constructor() { super('/User'); }

    async getWorkplaces(id: Guid): Promise<Result<WorkplaceDto[]>> {
        const result = await this.request('GET', `/${id}/employees`);

        if (result.isFailure) return result as Result<WorkplaceDto[]>;
        if (!Array.isArray(result.value)) return Result.FailureWith(new AppError('Validation.Error', 'Expected array of workplaces', -1));

        const validatedWorkplaces: WorkplaceDto[] = [];
        for (const item of result.value) {
            const validatedItem = validateWithSchema(WorkplaceSchema, item);
            if (validatedItem.isFailure) {
                return Result.FailureWith<WorkplaceDto[]>(validatedItem.error);
            }
            validatedWorkplaces.push(validatedItem.value);
        }
        return Result.SuccessWith(validatedWorkplaces);
    }
}
