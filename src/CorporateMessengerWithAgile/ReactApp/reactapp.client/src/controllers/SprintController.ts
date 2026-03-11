// src/controllers/SprintController.ts
import { AuthenticatedController } from './abstract/AuthenticatedController';
import { type Guid, Result, SprintSummaryDtoSchema } from '../models';
import { convertToArray } from '../utils/validation';
import { z } from 'zod';
import { AuthController } from '.';

export class SprintController extends AuthenticatedController {
    constructor(authController: AuthController) { super(authController, '/Sprint'); }

    async getSprintsByTeam(teamId: Guid): Promise<Result<z.infer<typeof SprintSummaryDtoSchema>[]>> {
        const result = await this.request('GET', `/team/${teamId}`);
        if (result.isFailure) return result as Result<z.infer<typeof SprintSummaryDtoSchema>[]>;
        return convertToArray(SprintSummaryDtoSchema, result.value);
    }
}
