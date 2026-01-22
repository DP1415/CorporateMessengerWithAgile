// src/models/entity/ProjectWithTeamsDto.ts
import { z } from 'zod';
import { ProjectDtoSchema } from './ProjectDto';
import { TeamDtoSchema } from './TeamDto';

export const ProjectWithTeamsDtoSchema = z.object({
    project: ProjectDtoSchema,
    teams: z.array(TeamDtoSchema),
});

export type ProjectWithTeamsDto = z.infer<typeof ProjectWithTeamsDtoSchema>;
