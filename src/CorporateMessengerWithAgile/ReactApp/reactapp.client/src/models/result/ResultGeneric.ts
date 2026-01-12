import { Error as AppError } from "./Error";

export class Result<T = void> {
    public readonly isSuccess: boolean;
    public readonly isFailure: boolean;
    public readonly value?: T;
    public readonly error?: AppError;

    private constructor(isSuccess: boolean, value?: T, error?: AppError) {
        if (isSuccess && error) {
            throw new Error("Успешный результат не может содержать ошибку");
        }
        if (!isSuccess && !error) {
            throw new Error("Неудачный результат должен содержать ошибку");
        }

        this.isSuccess = isSuccess;
        this.isFailure = !isSuccess;
        this.value = value;
        this.error = error;
    }

    public static success<T>(value?: T): Result<T> {
        return new Result<T>(true, value);
    }

    public static failure<T = void>(error: AppError): Result<T> {
        return new Result<T>(false, undefined, error);
    }

    public static ok(): Result<void> {
        return new Result<void>(true, undefined);
    }
}

// Export for compatibility
export type { Result as ResultGeneric };
