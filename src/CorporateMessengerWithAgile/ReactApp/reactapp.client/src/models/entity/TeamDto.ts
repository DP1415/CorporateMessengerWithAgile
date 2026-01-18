// src/models/entity/TeamDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TeamDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    title: z.string().min(1),
    standardSprintDuration: z.number(),
    teamMemberIds: z.array(GuidSchema).optional(),
    sprintIds: z.array(GuidSchema).optional(),
    kanbanBoardColumnIds: z.array(GuidSchema).optional(),
});

export type TeamDto = z.infer<typeof TeamDtoSchema>;
