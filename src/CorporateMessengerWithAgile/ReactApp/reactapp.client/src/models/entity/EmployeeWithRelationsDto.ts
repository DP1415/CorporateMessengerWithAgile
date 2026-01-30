// src/models/entity/EmployeeWithRelationsDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { CompanyDtoSchema } from './CompanyDto';
import { PositionInCompanyDtoSchema } from './PositionInCompanyDto';
import { TeamMemberDtoSchema } from './TeamMemberDto';

export const EmployeeWithRelationsSchema = BaseDtoSchema.extend({
    company: CompanyDtoSchema,
    positionInCompany: PositionInCompanyDtoSchema,
    teamMembers: z.array(TeamMemberDtoSchema).optional(),
});

export type EmployeeWithRelationsDto = z.infer<typeof EmployeeWithRelationsSchema>;
