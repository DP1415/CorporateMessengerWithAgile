import { AbstractController } from './AbstractController';
import { EmployeeWithCompanyAndPositionDto, Guid, Result } from '../models';

export class UserController extends AbstractController {
    constructor() { super('/User'); }

    async getEmployeesByUserId(id: Guid): Promise<Result<EmployeeWithCompanyAndPositionDto[]>> {
        return this.get<EmployeeWithCompanyAndPositionDto[]>(`/${id}/employees`);
    }
}
