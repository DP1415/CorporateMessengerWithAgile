// src/models/entity/EmployeeWithCompanyAndPositionDto.ts
import { z } from 'zod';
import { BaseDtoSchema } from './BaseDto';
import { CompanyDtoSchema } from './CompanyDto';
import { PositionInCompanyDtoSchema } from './PositionInCompanyDto';
import { UserDtoSchema } from './UserDto';
import { TeamMemberDtoSchema } from './TeamMemberDto';

export const EmployeeWithCompanyAndPositionDtoSchema = BaseDtoSchema.extend({
    company: CompanyDtoSchema,
    positionInCompany: PositionInCompanyDtoSchema,
    user: UserDtoSchema,
    teamMembers: z.array(TeamMemberDtoSchema).optional(),
});

export type EmployeeWithCompanyAndPositionDto = z.infer<typeof EmployeeWithCompanyAndPositionDtoSchema>;
