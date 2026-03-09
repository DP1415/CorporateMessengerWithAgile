// src/models/entity/ChatMemberSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const ChatMemberSummaryDtoSchema = BaseDtoSchema.extend({
    chatId: GuidSchema,
    userId: GuidSchema,
    isAdmin: z.boolean(),
});

export type ChatMemberSummaryDto = z.infer<typeof ChatMemberSummaryDtoSchema>;