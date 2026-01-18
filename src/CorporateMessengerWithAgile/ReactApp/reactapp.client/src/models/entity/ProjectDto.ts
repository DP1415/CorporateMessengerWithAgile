// src/models/entity/ProjectDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const ProjectDtoSchema = BaseDtoSchema.extend({
    companyId: GuidSchema,
    title: z.string().min(1),
    taskItemIds: z.array(GuidSchema).optional(),
    teamIds: z.array(GuidSchema).optional(),
});

export type ProjectDto = z.infer<typeof ProjectDtoSchema>;
