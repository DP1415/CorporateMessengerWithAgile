// src/models/entity/MessageSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const MessageSummaryDtoSchema = BaseDtoSchema.extend({
    content: z.string(),
    chatId: GuidSchema,
    senderId: GuidSchema,
    isEdited: z.boolean()
});

export type MessageSummaryDto = z.infer<typeof MessageSummaryDtoSchema>;