// src/controllers/EmployeeController.ts
import { AuthenticatedController } from './abstract/AuthenticatedController';
import {
    GuidSchema, Result,
    CompanySummaryDtoSchema,
    PositionInCompanySummaryDtoSchema,
    ProjectSummaryDtoSchema,
    TeamSummaryDtoSchema,
} from '../models';
import { convertToArray } from '../utils/validation';
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

export class EmployeeController extends AuthenticatedController {
    constructor(authController: AuthController) { super(authController, '/Employee'); }

    async getEmployeesWithRelations(): Promise<Result<EmployeeWithRelations[]>> {
        const result = await this.request('GET', `/employees`);
        if (result.isFailure) return result as Result<EmployeeWithRelations[]>;
        return convertToArray<EmployeeWithRelations>(EmployeeFullHierarchySchema, result.value);
    }
}
