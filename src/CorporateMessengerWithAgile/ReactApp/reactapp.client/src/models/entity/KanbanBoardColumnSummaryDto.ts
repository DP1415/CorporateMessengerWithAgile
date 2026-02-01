// src/models/entity/KanbanBoardColumnSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const KanbanBoardColumnSummaryDtoSchema = BaseDtoSchema.extend({
    teamId: GuidSchema,
    taskStatus: z.string().min(1),
    positionOnBoard: z.number(),
    title: z.string().min(1),
});

export type KanbanBoardColumnSummaryDto = z.infer<typeof KanbanBoardColumnSummaryDtoSchema>;
