// src/controllers/UserController.ts
import { AuthenticatedController } from './AuthenticatedController';
import {
    type Guid,
    Result,
    type WorkplaceDto,
    WorkplaceSchema,
    type ProjectWithTeamsDto,
    ProjectWithTeamsDtoSchema
} from '../models';
import { validateWithSchema } from '../utils/validation';
import { AppError } from '../models/result/AppError';
import type z from 'zod';

export class UserController extends AuthenticatedController {
    constructor() { super('/User'); }

    protected convertToArray<T>(arrayData: unknown, schema: z.ZodType<T>): Result<T[]> {
        if (!Array.isArray(arrayData)) {
            return Result.FailureWith(new AppError('Validation.Error', 'Expected array of workplaces', -1));
        }
        const validatedData: T[] = [];
        for (const item of arrayData) {
            const validatedItem = validateWithSchema(schema, item);
            if (validatedItem.isFailure) {
                return Result.FailureWith<T[]>(validatedItem.error);
            }
            validatedData.push(validatedItem.value);
        }
        return Result.SuccessWith(validatedData);
    }

    async getWorkplaces(id: Guid): Promise<Result<WorkplaceDto[]>> {
        const result = await this.request('GET', `/${id}/employees`);
        if (result.isFailure) return result as Result<WorkplaceDto[]>;
        return this.convertToArray<WorkplaceDto>(result.value, WorkplaceSchema);
    }

    async getProjectsAndTeams(employeeId: Guid): Promise<Result<ProjectWithTeamsDto[]>> {
        const result = await this.request('GET', `/${employeeId}/projects-and-teams`);
        if (result.isFailure) return result as Result<ProjectWithTeamsDto[]>;
        return this.convertToArray<ProjectWithTeamsDto>(result.value, ProjectWithTeamsDtoSchema);
    }
}
