import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class PositionInCompanyDto extends BaseDto {
    public companyId: Guid;
    public title: string;
    public description: string;
    public employeeIds: Guid[];

    constructor(
        id: Guid,
        companyId: Guid,
        title: string,
        description: string,
        employeeIds: Guid[]
    ) {
        super(id);
        this.companyId = companyId;
        this.title = title;
        this.description = description;
        this.employeeIds = employeeIds;
    }
}
