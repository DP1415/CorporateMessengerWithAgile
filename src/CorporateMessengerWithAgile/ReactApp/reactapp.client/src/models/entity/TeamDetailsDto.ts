// src/models/entity/TeamDetailsDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';
import { EmployeeDtoSchema } from './EmployeeDto';
import { SprintDtoSchema } from './SprintDto';

export const TeamDetailsDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    title: z.string(),
    standardSprintDuration: z.number(),
    users: z.array(EmployeeDtoSchema).default([]),
    sprints: z.array(SprintDtoSchema).default([]),
    kanbanBoardColumnIds: z.array(GuidSchema).optional(),
});

export type TeamDetailsDto = z.infer<typeof TeamDetailsDtoSchema>;
