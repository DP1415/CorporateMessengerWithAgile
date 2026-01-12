import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class TeamDto extends BaseDto {
    public projectId: Guid;
    public title: string;
    public standardSprintDuration: number;
    public teamMemberIds: Guid[];
    public sprintIds: Guid[];
    public kanbanBoardColumnIds: Guid[];

    constructor(
        id: Guid,
        projectId: Guid,
        title: string,
        standardSprintDuration: number,
        teamMemberIds: Guid[],
        sprintIds: Guid[],
        kanbanBoardColumnIds: Guid[]
    ) {
        super(id);
        this.projectId = projectId;
        this.title = title;
        this.standardSprintDuration = standardSprintDuration;
        this.teamMemberIds = teamMemberIds;
        this.sprintIds = sprintIds;
        this.kanbanBoardColumnIds = kanbanBoardColumnIds;
    }
}
