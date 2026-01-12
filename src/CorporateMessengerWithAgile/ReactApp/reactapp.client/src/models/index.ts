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
export { Error } from "./result/Error";
export { Result } from "./result/ResultGeneric";
export type { ResultVoid } from "./result/Result";
export { ResultFactory } from "./result/Result";
