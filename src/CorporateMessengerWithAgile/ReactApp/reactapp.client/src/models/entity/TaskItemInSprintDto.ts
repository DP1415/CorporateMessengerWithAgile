import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class TaskItemInSprintDto extends BaseDto {
    public taskItemId: Guid;
    public sprintId: Guid;
    public taskStatus: string;
    public description: string;

    constructor(
        id: Guid,
        taskItemId: Guid,
        sprintId: Guid,
        taskStatus: string,
        description: string
    ) {
        super(id);
        this.taskItemId = taskItemId;
        this.sprintId = sprintId;
        this.taskStatus = taskStatus;
        this.description = description;
    }
}
