// src/controllers/UserController.ts
import { AuthenticatedController } from './AuthenticatedController';
import {
    GuidSchema, type Guid, Result,
    CompanySummaryDtoSchema,
    PositionInCompanySummaryDtoSchema,
    ProjectSummaryDtoSchema,
    SprintSummaryDtoSchema,
    TaskItemSummaryDtoSchema,
    TaskItemWithStatusDtoSchema,
    TeamSummaryDtoSchema,
    type TaskItemSummaryDto,
    type TaskItemWithStatusDto
} from '../models';
import { convertToArray, validateWithSchema } from '../utils/validation';
import { z } from 'zod';
import { AuthController } from '.';

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

export class UserController extends AuthenticatedController {
    constructor(authController: AuthController) { super(authController, '/User'); }

    async getEmployeesWithRelations(userId: Guid): Promise<Result<EmployeeWithRelations[]>> {
        const result = await this.request('GET', `/${userId}/employees`);
        if (result.isFailure) return result as Result<EmployeeWithRelations[]>;
        return convertToArray<EmployeeWithRelations>(EmployeeFullHierarchySchema, result.value);
    }

    async getTaskItemsByProject(projectId: Guid): Promise<Result<TaskItemSummaryDto[]>> {
        const result = await this.request('GET', `/task-items/get-by-project/${projectId}`);
        if (result.isFailure) return result as Result<TaskItemSummaryDto[]>;
        return convertToArray<TaskItemSummaryDto>(TaskItemSummaryDtoSchema, result.value);
    }

    async getSprintsByTeam(teamId: Guid): Promise<Result<z.infer<typeof SprintSummaryDtoSchema>[]>> {
        const result = await this.request('GET', `/teams/${teamId}/sprints`);
        if (result.isFailure) return result as Result<z.infer<typeof SprintSummaryDtoSchema>[]>;
        return convertToArray(SprintSummaryDtoSchema, result.value);
    }

    async getTaskItemsBySprint(sprintId: Guid): Promise<Result<TaskItemSummaryDto[]>> {
        const result = await this.request('GET', `/sprints/${sprintId}/task-items`);
        if (result.isFailure) return result as Result<TaskItemSummaryDto[]>;
        return convertToArray<TaskItemSummaryDto>(TaskItemSummaryDtoSchema, result.value);
    }

    async getTaskItemsBySprintWithStatus(sprintId: Guid): Promise<Result<TaskItemWithStatusDto[]>> {
        const result = await this.request('GET', `/sprints/${sprintId}/task-items-with-status`);
        if (result.isFailure) return result as Result<TaskItemWithStatusDto[]>;
        return convertToArray<TaskItemWithStatusDto>(TaskItemWithStatusDtoSchema, result.value);
    }

    async createTaskItem(data: { title: string; description: string; priority: number; complexity: number; deadline: string; projectId: Guid; authorId: Guid; responsibleId: Guid; sprintWithLastMentionId?: Guid; parentTaskId?: Guid; }): Promise<Result<TaskItemSummaryDto>> {
        const result = await this.request('POST', '/task-items/create', data);
        if (result.isFailure) return result as Result<TaskItemSummaryDto>;
        return validateWithSchema(TaskItemSummaryDtoSchema, result.value);
    }

    async Logout() { return this.authController.Logout(); }

    //async getTeamDetails(teamId: Guid): Promise<Result<TeamDetailsDto>> {
    //    const result = await this.request('GET', `/teams/${teamId}`);
    //    if (result.isFailure) return result as Result<TeamDetailsDto>;
    //    return validateWithSchema(TeamDetailsDtoSchema, result.value);
    //}
}
