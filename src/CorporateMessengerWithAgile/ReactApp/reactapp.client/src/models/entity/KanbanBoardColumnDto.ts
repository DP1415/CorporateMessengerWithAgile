// src/models/entity/KanbanBoardColumnDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const KanbanBoardColumnDtoSchema = BaseDtoSchema.extend({
    teamId: GuidSchema,
    taskStatus: z.string().min(1),
    positionOnBoard: z.number(),
    title: z.string().min(1),
});

export type KanbanBoardColumnDto = z.infer<typeof KanbanBoardColumnDtoSchema>;
