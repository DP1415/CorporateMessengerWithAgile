// src/models/entity/EmployeeSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const EmployeeSummaryDtoSchema = BaseDtoSchema.extend({
    companyId: GuidSchema,
    positionInCompanyId: GuidSchema,
    userId: GuidSchema,
    teamMemberIds: z.array(GuidSchema).optional(),
});

export type EmployeeSummaryDto = z.infer<typeof EmployeeSummaryDtoSchema>;
