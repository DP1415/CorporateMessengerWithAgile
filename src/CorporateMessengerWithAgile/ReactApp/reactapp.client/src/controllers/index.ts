// src/controllers/index.ts

import { AuthController } from './AuthController';
import { EmployeeController } from './EmployeeController';
import { SprintController } from './SprintController';
import { TaskController } from './TaskController';
import { TeamController } from './TeamController';

export { AuthController } from './AuthController';
export { EmployeeController, type ProjectWithTeams, type EmployeeWithRelations } from './EmployeeController';
export { SprintController } from './SprintController'
export { TaskController } from './TaskController'
export { TeamController, type TeamWithRelationsDto } from './TeamController'

export class AppControllers {
    readonly Auth: AuthController
    readonly Employee: EmployeeController
    readonly Sprint: SprintController
    readonly Task: TaskController
    readonly Team: TeamController

    constructor() {
        this.Auth = new AuthController()
        this.Employee = new EmployeeController(this.Auth)
        this.Sprint = new SprintController(this.Auth)
        this.Task = new TaskController(this.Auth)
        this.Team = new TeamController(this.Auth)
    }
}
