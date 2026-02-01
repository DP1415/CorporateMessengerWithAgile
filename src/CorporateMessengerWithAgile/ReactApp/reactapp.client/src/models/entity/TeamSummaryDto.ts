// src/models/entity/TeamSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TeamSummaryDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    title: z.string().min(1),
    standardSprintDuration: z.number(),
    teamMemberIds: z.array(GuidSchema).optional(),
    sprintIds: z.array(GuidSchema).optional(),
    kanbanBoardColumnIds: z.array(GuidSchema).optional(),
});

export type TeamSummaryDto = z.infer<typeof TeamSummaryDtoSchema>;
