// src/models/entity/TaskItemDto.ts
import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class TaskItemDto extends BaseDto {
    public projectId: Guid;
    public authorId: Guid;
    public responsibleId: Guid;
    public sprintWithLastMentionId?: Guid;
    public parentTaskId?: Guid;
    public subtaskIds: Guid[];
    public title: string;
    public description: string;
    public priority: number;
    public complexity: number;
    public deadline: Date;

    constructor(
        id: Guid,
        projectId: Guid,
        authorId: Guid,
        responsibleId: Guid,
        title: string,
        description: string,
        priority: number,
        complexity: number,
        deadline: Date,
        sprintWithLastMentionId?: Guid,
        parentTaskId?: Guid,
        subtaskIds: Guid[] = []
    ) {
        super(id);
        this.projectId = projectId;
        this.authorId = authorId;
        this.responsibleId = responsibleId;
        this.sprintWithLastMentionId = sprintWithLastMentionId;
        this.parentTaskId = parentTaskId;
        this.subtaskIds = subtaskIds;
        this.title = title;
        this.description = description;
        this.priority = priority;
        this.complexity = complexity;
        this.deadline = deadline;
    }
}
