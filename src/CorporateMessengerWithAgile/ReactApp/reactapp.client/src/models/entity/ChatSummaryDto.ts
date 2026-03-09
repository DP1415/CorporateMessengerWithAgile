// src/models/entity/ChatSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const ChatSummaryDtoSchema = BaseDtoSchema.extend({
    name: z.string(),
    description: z.string(),
    ownerEmployeeId: GuidSchema.nullable(),
    ownerTeamId: GuidSchema.nullable()
});

export type ChatSummaryDto = z.infer<typeof ChatSummaryDtoSchema>;