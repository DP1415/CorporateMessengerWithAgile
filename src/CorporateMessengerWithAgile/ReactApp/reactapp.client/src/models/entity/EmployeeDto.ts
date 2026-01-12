import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class EmployeeDto extends BaseDto {
    public companyId: Guid;
    public positionInCompanyId: Guid;
    public userId: Guid;
    public teamMemberIds: Guid[];

    constructor(
        id: Guid,
        companyId: Guid,
        positionInCompanyId: Guid,
        userId: Guid,
        teamMemberIds: Guid[]
    ) {
        super(id);
        this.companyId = companyId;
        this.positionInCompanyId = positionInCompanyId;
        this.userId = userId;
        this.teamMemberIds = teamMemberIds;
    }
}
