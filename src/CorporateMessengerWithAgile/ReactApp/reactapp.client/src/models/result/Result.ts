import { AppError } from './AppError';

export class Result<T = void> {
    private readonly _isSuccess: boolean;
    private readonly _error?: AppError;
    private readonly _value?: T;

    protected constructor(isSuccess: boolean, error?: AppError, value?: T) {
        this._isSuccess = isSuccess;
        this._error = error;
        this._value = value;
    }

    get isSuccess(): boolean { return this._isSuccess; }
    get isFailure(): boolean { return !this._isSuccess; }

    get error(): AppError {
        if (this._isSuccess) throw new Error('Result.CannotAccessExceptionOnSuccess. Не возможно получить доступ к свойству error при успешном результате.');
        return this._error!;
    }
    get value(): T {
        if (!this._isSuccess) throw new Error('Result.CannotAccessValueOnFailure. Не возможно получить доступ к свойству value для неудачного результата.');
        return this._value!;
    }

    static Success(): Result { return new Result(true, undefined, undefined); }
    static Failure(error: AppError): Result { return new Result(false, error, undefined); }
    static SuccessWith<T>(value: T): Result<T> { return new Result(true, undefined, value); }
    static FailureWith<T>(error: AppError): Result<T> { return new Result(false, error, undefined as T); }
}