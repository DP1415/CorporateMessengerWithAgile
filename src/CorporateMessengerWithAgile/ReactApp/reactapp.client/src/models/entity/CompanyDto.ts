import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class CompanyDto extends BaseDto {
    public title: string;
    public employeeIds: Guid[];
    public positionIds: Guid[];
    public projectIds: Guid[];

    constructor(
        id: Guid,
        title: string,
        employeeIds: Guid[],
        positionIds: Guid[],
        projectIds: Guid[]
    ) {
        super(id);
        this.title = title;
        this.employeeIds = employeeIds;
        this.positionIds = positionIds;
        this.projectIds = projectIds;
    }
}
