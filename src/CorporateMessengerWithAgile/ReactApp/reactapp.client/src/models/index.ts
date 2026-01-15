// src/models/index.ts
// Экспорт интерфейсов и типов
export type { IGuid } from "./IGuid";
export { Guid } from "./Guid";

// Экспорт DTO
export { BaseDto } from "./entity/BaseDto";
export { UserDto } from "./entity/UserDto";
export { CompanyDto } from "./entity/CompanyDto";
export { PositionInCompanyDto } from "./entity/PositionInCompanyDto";
export { EmployeeDto } from "./entity/EmployeeDto";
export { EmployeeWithCompanyAndPositionDto } from "./entity/EmployeeWithCompanyAndPositionDto";
export { KanbanBoardColumnDto } from "./entity/KanbanBoardColumnDto";
export { ProjectDto } from "./entity/ProjectDto";
export { SprintDto } from "./entity/SprintDto";
export { TaskItemDto } from "./entity/TaskItemDto";
export { TaskItemInSprintDto } from "./entity/TaskItemInSprintDto";
export { TeamDto } from "./entity/TeamDto";
export { TeamMemberDto } from "./entity/TeamMemberDto";

// Экспорт результатов и ошибок
export { AppError } from "./result/AppError";
export { Result } from "./result/Result";
