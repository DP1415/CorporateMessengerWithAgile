// src/controllers/TaskController.ts
import { AuthenticatedController } from './abstract/AuthenticatedController';
import {
    type Guid, Result,
    TaskItemSummaryDtoSchema,
    TaskItemWithStatusDtoSchema,
    type TaskItemSummaryDto,
    type TaskItemWithStatusDto
} from '../models';
import { convertToArray, validateWithSchema } from '../utils/validation';
import { AuthController } from '.';

export class TaskController extends AuthenticatedController {
    constructor(authController: AuthController) { super(authController, '/Task'); }

    async getTaskItemsBySprintWithStatus(sprintId: Guid): Promise<Result<TaskItemWithStatusDto[]>> {
        const result = await this.request('GET', `/sprint/${sprintId}/task-items-with-status`);
        if (result.isFailure) return result as Result<TaskItemWithStatusDto[]>;
        return convertToArray<TaskItemWithStatusDto>(TaskItemWithStatusDtoSchema, result.value);
    }

    async getTaskItemsBySprint(sprintId: Guid): Promise<Result<TaskItemSummaryDto[]>> {
        const result = await this.request('GET', `/sprint/${sprintId}/task-items`);
        if (result.isFailure) return result as Result<TaskItemSummaryDto[]>;
        return convertToArray<TaskItemSummaryDto>(TaskItemSummaryDtoSchema, result.value);
    }

    async getTaskItemsByProject(projectId: Guid): Promise<Result<TaskItemSummaryDto[]>> {
        const result = await this.request('GET', `/project/${projectId}`);
        if (result.isFailure) return result as Result<TaskItemSummaryDto[]>;
        return convertToArray<TaskItemSummaryDto>(TaskItemSummaryDtoSchema, result.value);
    }

    async createTaskItem(data: { title: string; description: string; priority: number; complexity: number; deadline: string; projectId: Guid; authorId: Guid; responsibleId: Guid; sprintWithLastMentionId?: Guid; parentTaskId?: Guid; }): Promise<Result<TaskItemSummaryDto>> {
        const result = await this.request('POST', '', data);
        if (result.isFailure) return result as Result<TaskItemSummaryDto>;
        return validateWithSchema(TaskItemSummaryDtoSchema, result.value);
    }
}
