// src/models/entity/UserDto.ts
import { BaseDto } from "./BaseDto";
import { Guid } from "../Guid";

export class UserDto extends BaseDto {
    public email: string;
    public username: string;
    public phoneNumber: string;
    public role: string;
    public employeeIds: Guid[];

    constructor(
        id: Guid,
        email: string,
        username: string,
        phoneNumber: string,
        role: string,
        employeeIds: Guid[]
    ) {
        super(id);
        this.email = email;
        this.username = username;
        this.phoneNumber = phoneNumber;
        this.role = role;
        this.employeeIds = employeeIds;
    }
}
