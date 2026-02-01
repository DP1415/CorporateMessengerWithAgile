// src/models/entity/CompanySummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const CompanySummaryDtoSchema = BaseDtoSchema.extend({
    title: z.string().min(1),
    employeeIds: z.array(GuidSchema).optional(),
    positionIds: z.array(GuidSchema).optional(),
    projectIds: z.array(GuidSchema).optional(),
});

export type CompanySummaryDto = z.infer<typeof CompanySummaryDtoSchema>;
