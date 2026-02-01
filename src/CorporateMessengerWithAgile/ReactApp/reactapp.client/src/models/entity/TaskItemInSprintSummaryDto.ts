// src/models/entity/TaskItemInSprintSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TaskItemInSprintSummaryDtoSchema = BaseDtoSchema.extend({
    taskItemId: GuidSchema,
    sprintId: GuidSchema,
    taskStatus: z.string().min(1),
    description: z.string(),
});

export type TaskItemInSprintSummaryDto = z.infer<typeof TaskItemInSprintSummaryDtoSchema>;
