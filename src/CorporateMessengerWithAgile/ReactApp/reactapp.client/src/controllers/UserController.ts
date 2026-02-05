// src/controllers/UserController.ts
import { AuthenticatedController } from './AuthenticatedController';
import {
    GuidSchema, type Guid, Result,
    CompanySummaryDtoSchema,
    PositionInCompanySummaryDtoSchema,
    ProjectSummaryDtoSchema,
    TeamSummaryDtoSchema
} from '../models';
import { validateWithSchema } from '../utils/validation';
import { AppError } from '../models/result/AppError';
import { z } from 'zod';

const ProjectWithTeamsSchema = z.object({
    project: ProjectSummaryDtoSchema,
    teams: z.array(TeamSummaryDtoSchema),
});
export type ProjectWithTeams = z.infer<typeof ProjectWithTeamsSchema>;

const EmployeeFullHierarchySchema = z.object({
    employeeId: GuidSchema,
    company: CompanySummaryDtoSchema,
    positionInCompany: PositionInCompanySummaryDtoSchema,
    projectsAndTeams: z.array(ProjectWithTeamsSchema).default([]),
});
export type EmployeeWithRelations = z.infer<typeof EmployeeFullHierarchySchema>;

//const TeamDetailsDtoSchema = BaseDtoSchema.extend({
//    projectId: GuidSchema,
//    title: z.string(),
//    standardSprintDuration: z.number(),
//    users: z.array(EmployeeSummaryDtoSchema).default([]),
//    sprints: z.array(SprintSummaryDtoSchema).default([]),
//    kanbanBoardColumnIds: z.array(GuidSchema).optional(),
//});
//export type TeamDetailsDto = z.infer<typeof TeamDetailsDtoSchema>;

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

    async getEmployeesWithRelations(userId: Guid): Promise<Result<EmployeeWithRelations[]>> {
        const result = await this.request('GET', `/${userId}/employees`);
        if (result.isFailure) return result as Result<EmployeeWithRelations[]>;
        return this.convertToArray<EmployeeWithRelations>(result.value, EmployeeFullHierarchySchema);
    }

    //async getTeamDetails(teamId: Guid): Promise<Result<TeamDetailsDto>> {
    //    const result = await this.request('GET', `/teams/${teamId}`);
    //    if (result.isFailure) return result as Result<TeamDetailsDto>;
    //    return validateWithSchema(TeamDetailsDtoSchema, result.value);
    //}
}
