// src/models/entity/UserSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const UserSummaryDtoSchema = BaseDtoSchema.extend({
    email: z.email(),
    username: z.string().min(1),
    phoneNumber: z.string().nullable().optional(),
    role: z.string().min(1),
    employeeIds: z.array(GuidSchema).optional(),
});

export type UserSummaryDto = z.infer<typeof UserSummaryDtoSchema>;