// src/controllers/TeamController.ts
import { AuthenticatedController } from './abstract/AuthenticatedController';
import { BaseDtoSchema, type Guid, GuidSchema, Result } from '../models';
import { validateWithSchema } from '../utils/validation';
import { z } from 'zod';
import { AuthController } from '.';

const TeamWithRelationsDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    title: z.string().min(1),
    standardSprintDuration: z.number(),
    teamMemberIds: z.array(GuidSchema).optional(),
    sprintIds: z.array(GuidSchema).optional(),
    kanbanBoardColumnIds: z.array(GuidSchema).optional(),
});

export type TeamWithRelationsDto = z.infer<typeof TeamWithRelationsDtoSchema>;

export class TeamController extends AuthenticatedController {
    constructor(authController: AuthController) { super(authController, '/Team'); }

    async getTeamDetails(teamId: Guid): Promise<Result<TeamWithRelationsDto>> {
        const result = await this.request('GET', `/${teamId}`);
        if (result.isFailure) return result as Result<TeamWithRelationsDto>;
        return validateWithSchema(TeamWithRelationsDtoSchema, result.value);
    }
}
