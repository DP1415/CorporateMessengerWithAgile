import type { UUID, Result_T, CompanyDto, CompanyGetByIdDto } from "../models/typesdto";


const API_BASE = 'https://localhost:5018/cmwa'; // Общий префикс

export const companyApi = {
    // Список компаний (базовый)
    async getAll(): Promise<CompanyDto[]> {
        const res = await fetch(`${API_BASE}/reports/company`);        
        if (!res.ok) throw new Error('Не удалось загрузить компании');
        return res.json();
    },

    // Детали компании по ID (расширенные данные)
    async getById(id: UUID): Promise<Result_T<CompanyGetByIdDto>> {
        const res = await fetch(`${API_BASE}/reports/company/${id}`);
        if (!res.ok) throw new Error('Не удалось загрузить компанию');
        return res.json();
    },
};