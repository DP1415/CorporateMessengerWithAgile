// src/models/entity/TaskItemDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TaskItemDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    authorId: GuidSchema,
    responsibleId: GuidSchema,
    sprintWithLastMentionId: GuidSchema.optional(),
    parentTaskId: GuidSchema.optional(),
    subtaskIds: z.array(GuidSchema).optional(),
    title: z.string().min(1),
    description: z.string(),
    priority: z.number(),
    complexity: z.number(),
    deadline: z.coerce.date(),
});

export type TaskItemDto = z.infer<typeof TaskItemDtoSchema>;
