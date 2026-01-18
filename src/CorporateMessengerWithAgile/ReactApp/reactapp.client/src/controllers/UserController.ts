// src/controllers/UserController.ts
import { AuthenticatedController } from './AuthenticatedController';
import {
    type EmployeeWithCompanyAndPositionDto,
    EmployeeWithCompanyAndPositionDtoSchema,
    type Guid,
    Result
} from '../models';
import { validateWithSchema } from '../utils/validation';
import { AppError } from '../models/result/AppError';

export class UserController extends AuthenticatedController {
    constructor() {
        super('/User');
    }

    async getEmployeesByUserId(id: Guid): Promise<Result<EmployeeWithCompanyAndPositionDto[]>> {
        const result = await this.request('GET', `/${id}/employees`);
        if (result.isFailure) {
            return result as Result<EmployeeWithCompanyAndPositionDto[]>;
        }

        const rawData = result.value;

        if (!Array.isArray(rawData)) {
            return Result.FailureWith(
                new AppError('Validation.Error', 'Expected array of employees', 0)
            );
        }

        const validatedEmployees: EmployeeWithCompanyAndPositionDto[] = [];
        for (const item of rawData) {
            const validatedItem = validateWithSchema(EmployeeWithCompanyAndPositionDtoSchema, item);
            if (validatedItem.isFailure) {
                return Result.FailureWith<EmployeeWithCompanyAndPositionDto[]>(validatedItem.error);
            }
            validatedEmployees.push(validatedItem.value);
        }

        return Result.SuccessWith(validatedEmployees);
    }
}