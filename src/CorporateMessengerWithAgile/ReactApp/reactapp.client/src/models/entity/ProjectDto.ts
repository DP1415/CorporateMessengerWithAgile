// src/models/entity/ProjectDto.ts
import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class ProjectDto extends BaseDto {
    public companyId: Guid;
    public title: string;
    public taskItemIds: Guid[];
    public teamIds: Guid[];

    constructor(
        id: Guid,
        companyId: Guid,
        title: string,
        taskItemIds: Guid[],
        teamIds: Guid[]
    ) {
        super(id);
        this.companyId = companyId;
        this.title = title;
        this.taskItemIds = taskItemIds;
        this.teamIds = teamIds;
    }
}
