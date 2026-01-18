// src/models/entity/TeamMemberDto.ts
import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class TeamMemberDto extends BaseDto {
    public employeeId: Guid;
    public teamId: Guid;

    constructor(
        id: Guid,
        employeeId: Guid,
        teamId: Guid
    ) {
        super(id);
        this.employeeId = employeeId;
        this.teamId = teamId;
    }
}
