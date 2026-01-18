// src/models/entity/EmployeeDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const EmployeeDtoSchema = BaseDtoSchema.extend({
    companyId: GuidSchema,
    positionInCompanyId: GuidSchema,
    userId: GuidSchema,
    teamMemberIds: z.array(GuidSchema).optional(),
});

export type EmployeeDto = z.infer<typeof EmployeeDtoSchema>;
