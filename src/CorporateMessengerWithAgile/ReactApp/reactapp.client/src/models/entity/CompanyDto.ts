// src/models/entity/CompanyDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const CompanyDtoSchema = BaseDtoSchema.extend({
    title: z.string().min(1),
    employeeIds: z.array(GuidSchema).optional(),
    positionIds: z.array(GuidSchema).optional(),
    projectIds: z.array(GuidSchema).optional(),
});

export type CompanyDto = z.infer<typeof CompanyDtoSchema>;
