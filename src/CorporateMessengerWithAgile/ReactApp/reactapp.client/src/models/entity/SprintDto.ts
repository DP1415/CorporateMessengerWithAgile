import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class SprintDto extends BaseDto {
    public teamId: Guid;
    public dateStart: Date;
    public dateEnd: Date;
    public taskItemIds: Guid[];

    constructor(
        id: Guid,
        teamId: Guid,
        dateStart: Date,
        dateEnd: Date,
        taskItemIds: Guid[]
    ) {
        super(id);
        this.teamId = teamId;
        this.dateStart = dateStart;
        this.dateEnd = dateEnd;
        this.taskItemIds = taskItemIds;
    }
}
