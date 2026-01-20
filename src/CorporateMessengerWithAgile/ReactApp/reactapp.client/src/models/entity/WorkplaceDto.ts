// src/models/entity/WorkplaceDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { CompanyDtoSchema } from './CompanyDto';
import { PositionInCompanyDtoSchema } from './PositionInCompanyDto';
import { TeamMemberDtoSchema } from './TeamMemberDto';

export const WorkplaceSchema = BaseDtoSchema.extend({
    company: CompanyDtoSchema,
    positionInCompany: PositionInCompanyDtoSchema,
    teamMembers: z.array(TeamMemberDtoSchema).optional(),
});

export type WorkplaceDto = z.infer<typeof WorkplaceSchema>;
