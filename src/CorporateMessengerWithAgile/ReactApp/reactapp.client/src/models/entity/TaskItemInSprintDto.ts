// src/models/entity/TaskItemInSprintDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TaskItemInSprintDtoSchema = BaseDtoSchema.extend({
    taskItemId: GuidSchema,
    sprintId: GuidSchema,
    taskStatus: z.string().min(1),
    description: z.string(),
});

export type TaskItemInSprintDto = z.infer<typeof TaskItemInSprintDtoSchema>;
