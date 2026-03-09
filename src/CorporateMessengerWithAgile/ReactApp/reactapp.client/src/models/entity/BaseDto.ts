// src/models/entity/BaseDto.ts
import { z } from 'zod';
import { GuidSchema } from '../Guid';

export const BaseDtoSchema = z.object({
    id: GuidSchema,
});

export type BaseDto = z.infer<typeof BaseDtoSchema>;

export const BaseEntityWithChatsDtoSchema = BaseDtoSchema.extend({
    chatIds: z.array(GuidSchema).optional(),
});

export type BaseEntityWithChatsDto = z.infer<typeof BaseEntityWithChatsDtoSchema>;
