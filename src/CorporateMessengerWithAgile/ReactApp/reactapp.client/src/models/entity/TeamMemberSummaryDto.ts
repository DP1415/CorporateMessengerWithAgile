// src/models/entity/TeamMemberSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TeamMemberSummaryDtoSchema = BaseDtoSchema.extend({
    employeeId: GuidSchema,
    teamId: GuidSchema,
});

export type TeamMemberSummaryDto = z.infer<typeof TeamMemberSummaryDtoSchema>;
