import { UserSummaryDto } from './UserSummaryDto';
import { ProjectSummaryDto } from './ProjectSummaryDto';
import { SprintSummaryDto } from './SprintSummaryDto';

export interface TaskItemWithStatusDto {
  id: string;
  projectId: string;
  authorId: string;
  responsibleId: string | null;
  sprintWithLastMentionId: string | null;
  parentTaskId: string | null;
  subtaskIds: string[];
  title: string;
  description: string;
  priority: number;
  complexity: number;
  deadline: string;
  project: ProjectSummaryDto | null;
  author: UserSummaryDto | null;
  responsible: UserSummaryDto | null;
  sprintWithLastMention: SprintSummaryDto | null;
  parentTask: TaskItemWithStatusDto | null;
  subtasks: TaskItemWithStatusDto[];
  taskStatus: number; // TaskItemStatus enum value
}
