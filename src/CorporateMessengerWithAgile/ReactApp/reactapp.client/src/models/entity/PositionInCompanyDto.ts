// src/models/entity/PositionInCompanyDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const PositionInCompanyDtoSchema = BaseDtoSchema.extend({
    companyId: GuidSchema,
    title: z.string().min(1),
    description: z.string(),
    employeeIds: z.array(GuidSchema).optional(),
});

export type PositionInCompanyDto = z.infer<typeof PositionInCompanyDtoSchema>;
