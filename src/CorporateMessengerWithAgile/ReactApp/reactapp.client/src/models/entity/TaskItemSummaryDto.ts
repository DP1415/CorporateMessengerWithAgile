// src/models/entity/TaskItemSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TaskItemSummaryDtoSchema = BaseDtoSchema.extend({
    projectId: GuidSchema,
    authorId: GuidSchema,
    responsibleId: GuidSchema,
    sprintWithLastMentionId: GuidSchema.nullish(),
    parentTaskId: GuidSchema.nullish(),
    subtaskIds: z.array(GuidSchema).optional(),
    title: z.string().min(1),
    description: z.string(),
    priority: z.number(),
    complexity: z.number(),
    deadline: z.coerce.date(),
});

export type TaskItemSummaryDto = z.infer<typeof TaskItemSummaryDtoSchema>;
