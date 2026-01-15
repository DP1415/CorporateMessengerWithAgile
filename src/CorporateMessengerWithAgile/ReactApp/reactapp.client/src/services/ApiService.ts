// src/services/ApiService.ts
import { AuthController } from '../controllers/AuthController';
import { UserController } from '../controllers/UserController';

// Основной сервис API, предоставляющий доступ ко всем контроллерам
class ApiService {
    public readonly auth: AuthController;
    public readonly users: UserController;

    constructor() {
        this.auth = new AuthController();
        this.users = new UserController();
    }
}

// Синглтон экземпляр
const apiService = new ApiService();

export { apiService, ApiService };
