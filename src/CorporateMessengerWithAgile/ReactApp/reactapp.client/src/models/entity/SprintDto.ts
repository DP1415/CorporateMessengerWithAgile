// src/models/entity/SprintDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const SprintDtoSchema = BaseDtoSchema.extend({
    teamId: GuidSchema,
    dateStart: z.coerce.date(),
    dateEnd: z.coerce.date(),
    taskItemIds: z.array(GuidSchema).optional(),
});

export type SprintDto = z.infer<typeof SprintDtoSchema>;
