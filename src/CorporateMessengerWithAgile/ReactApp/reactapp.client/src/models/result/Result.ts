import { Result as ResultGeneric } from "./ResultGeneric";
import { Error as AppError } from "./Error";

// Для совместимости создаем alias для необобщенного результата
export type ResultVoid = ResultGeneric<void>;
export { ResultGeneric as Result };

export class ResultFactory {
    static success<T>(value?: T): ResultGeneric<T> {
        return ResultGeneric.success(value);
    }

    static failure<T = void>(error: AppError): ResultGeneric<T> {
        return ResultGeneric.failure(error);
    }

    static ok(): ResultGeneric<void> {
        return ResultGeneric.ok();
    }
}
