import { Guid } from "../Guid";

export abstract class BaseDto {
    public id: Guid;

    constructor(id: Guid) {
        this.id = id;
    }
}
