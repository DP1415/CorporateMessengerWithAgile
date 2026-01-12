import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class KanbanBoardColumnDto extends BaseDto {
    public teamId: Guid;
    public taskStatus: string;
    public positionOnBoard: number;
    public title: string;

    constructor(
        id: Guid,
        teamId: Guid,
        taskStatus: string,
        positionOnBoard: number,
        title: string
    ) {
        super(id);
        this.teamId = teamId;
        this.taskStatus = taskStatus;
        this.positionOnBoard = positionOnBoard;
        this.title = title;
    }
}
