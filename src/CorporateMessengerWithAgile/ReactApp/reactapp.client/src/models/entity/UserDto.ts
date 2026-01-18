// src/models/entity/UserDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const UserDtoSchema = BaseDtoSchema.extend({
    email: z.email(),
    username: z.string().min(1),
    phoneNumber: z.string().nullable().optional(),
    role: z.string().min(1),
    employeeIds: z.array(GuidSchema).optional(),
});

export type UserDto = z.infer<typeof UserDtoSchema>;