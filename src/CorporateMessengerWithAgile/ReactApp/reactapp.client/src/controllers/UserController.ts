// src/controllers/UserController.ts
import { AuthenticatedController } from './AuthenticatedController';
import {
    GuidSchema, type Guid, Result,
    BaseDtoSchema,
    CompanySummaryDtoSchema, PositionInCompanySummaryDtoSchema, TeamMemberSummaryDtoSchema,
    ProjectSummaryDtoSchema, TeamSummaryDtoSchema,
    EmployeeSummaryDtoSchema, SprintSummaryDtoSchema
} from '../models';
import { validateWithSchema } from '../utils/validation';
import { AppError } from '../models/result/AppError';
import { z } from 'zod';

const EmployeeWithRelationsSchema = BaseDtoSchema.extend({
    company: CompanySummaryDtoSchema,
    positionInCompany: PositionInCompanySummaryDtoSchema,
    teamMembers: z.array(TeamMemberSummaryDtoSchema).optional(),
});
export type EmployeeWithRelationsDto = z.infer<typeof EmployeeWithRelationsSchema>;

const ProjectWithTeamsDtoSchema = z.object({
    project: ProjectSummaryDtoSchema,
    teams: z.array(TeamSummaryDtoSchema),
});
export type ProjectWithTeamsDto = z.infer<typeof ProjectWithTeamsDtoSchema>;

const TeamDetailsDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    title: z.string(),
    standardSprintDuration: z.number(),
    users: z.array(EmployeeSummaryDtoSchema).default([]),
    sprints: z.array(SprintSummaryDtoSchema).default([]),
    kanbanBoardColumnIds: z.array(GuidSchema).optional(),
});
export type TeamDetailsDto = z.infer<typeof TeamDetailsDtoSchema>;

export class UserController extends AuthenticatedController {
    constructor() { super('/User'); }

    protected convertToArray<T>(arrayData: unknown, schema: z.ZodType<T>): Result<T[]> {
        if (!Array.isArray(arrayData)) {
            return Result.FailureWith(new AppError('Validation.Error', 'The received data is not an array', -1));
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

    async getEmployeesWithRelations(userId: Guid): Promise<Result<EmployeeWithRelationsDto[]>> {
        const result = await this.request('GET', `/${userId}/employees`);
        if (result.isFailure) return result as Result<EmployeeWithRelationsDto[]>;
        return this.convertToArray<EmployeeWithRelationsDto>(result.value, EmployeeWithRelationsSchema);
    }

    async getProjectsAndTeams(employeeId: Guid): Promise<Result<ProjectWithTeamsDto[]>> {
        const result = await this.request('GET', `/${employeeId}/projects-and-teams`);
        if (result.isFailure) return result as Result<ProjectWithTeamsDto[]>;
        return this.convertToArray<ProjectWithTeamsDto>(result.value, ProjectWithTeamsDtoSchema);
    }

    async getTeamDetails(teamId: Guid): Promise<Result<TeamDetailsDto>> {
        const result = await this.request('GET', `/teams/${teamId}`);
        if (result.isFailure) return result as Result<TeamDetailsDto>;
        return validateWithSchema(TeamDetailsDtoSchema, result.value);
    }
}
