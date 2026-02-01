// src/models/entity/ProjectSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const ProjectSummaryDtoSchema = BaseDtoSchema.extend({
    companyId: GuidSchema,
    title: z.string().min(1),
    taskItemIds: z.array(GuidSchema).optional(),
    teamIds: z.array(GuidSchema).optional(),
});

export type ProjectSummaryDto = z.infer<typeof ProjectSummaryDtoSchema>;
