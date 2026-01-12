import type { IGuid } from "./IGuid";

const GUID_REGEX: RegExp = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/;

export class Guid implements IGuid {
    private _value: string;

    public get value(): string { return this._value; }

    private constructor(value: string, skipValidation: boolean = false) {
        if (skipValidation) {
            this._value = value;
        } else {
            if (typeof value !== 'string' || !GUID_REGEX.test(value)) {
                throw new Error("Invalid GUID format");
            }
            this._value = value.toLowerCase();
        }
    }

    static newGuid(): Guid {
        const guid: string = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(
            /[xy]/g,
            (c: string): string => {
                const r: number = (Math.random() * 16) | 0;
                const v: number = c === 'x' ? r : (r & 0x3) | 0x8;
                return v.toString(16);
            }
        );
        return new Guid(guid, true);
    }

    static isValid(value: unknown): boolean {
        return typeof value === 'string' && GUID_REGEX.test(value);
    }

    public equals(other: unknown): boolean {
        if (other === null || other === undefined) {
            return false;
        }
        if (!(other instanceof Guid)) {
            return false;
        }
        return this._value === other._value;
    }
}