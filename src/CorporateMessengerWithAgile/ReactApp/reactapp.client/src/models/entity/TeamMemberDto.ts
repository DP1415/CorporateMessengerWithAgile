// src/models/entity/TeamMemberDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const TeamMemberDtoSchema = BaseDtoSchema.extend({
    employeeId: GuidSchema,
    teamId: GuidSchema,
});

export type TeamMemberDto = z.infer<typeof TeamMemberDtoSchema>;
