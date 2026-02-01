// src/models/entity/PositionInCompanySummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const PositionInCompanySummaryDtoSchema = BaseDtoSchema.extend({
    companyId: GuidSchema,
    title: z.string().min(1),
    description: z.string(),
    employeeIds: z.array(GuidSchema).optional(),
});

export type PositionInCompanySummaryDto = z.infer<typeof PositionInCompanySummaryDtoSchema>;
