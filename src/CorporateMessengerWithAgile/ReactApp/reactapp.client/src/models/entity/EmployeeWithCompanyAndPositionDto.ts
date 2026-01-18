// src/models/entity/EmployeeWithCompanyAndPositionDto.ts
import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";
import { CompanyDto } from "./CompanyDto";
import { PositionInCompanyDto } from "./PositionInCompanyDto";
import { UserDto } from "./UserDto";
import { TeamMemberDto } from "./TeamMemberDto";

export class EmployeeWithCompanyAndPositionDto extends BaseDto {
    public company: CompanyDto;
    public positionInCompany: PositionInCompanyDto;
    public user: UserDto;
    public teamMembers: TeamMemberDto[];

    constructor(
        id: Guid,
        company: CompanyDto,
        positionInCompany: PositionInCompanyDto,
        user: UserDto,
        teamMembers: TeamMemberDto[]
    ) {
        super(id);
        this.company = company;
        this.positionInCompany = positionInCompany;
        this.user = user;
        this.teamMembers = teamMembers;
    }
}
