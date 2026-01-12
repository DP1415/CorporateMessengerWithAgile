import { AbstractController } from './AbstractController';
import { Result } from '../models/result/ResultGeneric';
import { EmployeeWithCompanyAndPositionDto } from '../models/entity/EmployeeWithCompanyAndPositionDto';
import type { Guid } from '../models';

export class UserController extends AbstractController {
    constructor() {
        super('/User');
    }

    async getEmployeesByUserId(id: Guid): Promise<Result<EmployeeWithCompanyAndPositionDto[]>> {
        return this.get<EmployeeWithCompanyAndPositionDto[]>(`/${id}/employees`);
    }
}
