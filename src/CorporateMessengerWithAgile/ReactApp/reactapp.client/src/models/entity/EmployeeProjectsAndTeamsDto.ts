// src/models/entity/EmployeeProjectsAndTeamsDto.ts
import { z } from 'zod';
import { ProjectDtoSchema } from './ProjectDto';
import { TeamDtoSchema } from './TeamDto';

export const EmployeeProjectsAndTeamsDtoSchema = z.object({
    projects: z.array(ProjectDtoSchema).optional(),
    teams: z.array(TeamDtoSchema).optional(),
});

export type EmployeeProjectsAndTeamsDto = z.infer<typeof EmployeeProjectsAndTeamsDtoSchema>;
