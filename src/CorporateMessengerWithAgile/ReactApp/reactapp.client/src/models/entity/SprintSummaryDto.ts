// src/models/entity/SprintSummaryDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { GuidSchema } from '../Guid';

export const SprintSummaryDtoSchema = BaseDtoSchema.extend({
    teamId: GuidSchema,
    dateStart: z.coerce.date(),
    dateEnd: z.coerce.date(),
    taskItemIds: z.array(GuidSchema).optional(),
});

export type SprintSummaryDto = z.infer<typeof SprintSummaryDtoSchema>;
