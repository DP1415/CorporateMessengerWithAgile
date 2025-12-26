export type UUID = string;


export interface Result {
    isSuccess: boolean;
}

export interface Result_T<T> {
    isSuccess: boolean;
    value?: T;
}

export enum TaskItemStatus {
    Backlog = 0,
    Todo = 1,
    // Возможно, будут добавлены другие статусы позже
}

export interface CompanyDto {
    id: UUID;
    title: string | null;
    employeeIds: UUID[] | null;
    positionIds: UUID[] | null;
    projectIds: UUID[] | null;
}

export interface EmployeeDto {
    id: UUID;
    companyId: UUID;
    positionInCompanyId: UUID;
    userId: UUID;
    teamMemberIds: UUID[] | null;
}

export interface PositionInCompanyDto {
    id: UUID;
    companyId: UUID;
    title: string | null;
    description: string | null;
    employeeIds: UUID[] | null;
}

export interface ProjectDto {
    id: UUID;
    companyId: UUID;
    title: string | null;
    taskItemIds: UUID[] | null;
    teamIds: UUID[] | null;
}

export interface TaskItemDto {
    id: UUID;
    projectId: UUID;
    authorId: UUID;
    responsibleId: UUID;
    sprintWithLastMentionId: UUID | null;
    parentTaskId: UUID | null;
    subtaskIds: UUID[] | null;
    title: string | null;
    description: string | null;
    priority: number; // int32
    complexity: number; // int32
    deadline: string; // date-time
}

export interface UserDto {
    id: UUID;
    email: string | null;
    username: string | null;
    employeeIds: UUID[] | null;
}

export interface TeamDto {
    id: UUID;
    projectId: UUID;
    title: string | null;
    standardSprintDuration: number; // int32
    teamMemberIds: UUID[] | null;
    sprintIds: UUID[] | null;
    kanbanBoardColumnIds: UUID[] | null;
}

export interface SprintDto {
    id: UUID;
    teamId: UUID;
    dateStart: string; // date-time
    dateEnd: string; // date-time
    taskItemIds: UUID[] | null;
}

export interface KanbanBoardColumnDto {
    id: UUID;
    teamId: UUID;
    taskStatus: TaskItemStatus;
    positionOnBoard: number; // int32
    title: string | null;
}

export interface TaskItemInSprintDto {
    id: UUID;
    taskItemId: UUID;
    sprintId: UUID;
    taskStatus: TaskItemStatus;
    description: string | null;
}

export interface TeamMemberDto {
    id: UUID;
    employeeId: UUID;
    teamId: UUID;
}


export interface CompanyGetByIdDto {
    companyDto: CompanyDto;
    projectDtos: ProjectDto[] | null;
    employeeDtos: EmployeeDto[] | null;
    positionInCompanyDtos: PositionInCompanyDto[] | null;
    userDtos: UserDto[] | null;
}