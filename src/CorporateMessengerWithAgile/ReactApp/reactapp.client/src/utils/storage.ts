// src/utils/storage.ts
import { z } from 'zod';

/**
 * Загружает и валидирует данные из localStorage через Zod-схему.
 * @param key - ключ в localStorage
 * @param schema - Zod-схема для валидации
 * @returns данные типа T или null, если ошибка
 */
export function loadFromStorage<T>(key: string, schema: z.ZodType<T>): T | null {
    try {
        const item = localStorage.getItem(key);
        if (item === null) return null;

        const result = schema.safeParse(JSON.parse(item));
        if (result.success) return result.data;

        console.error(`Validation failed for key "${key}":`, result.error.issues);
        localStorage.removeItem(key);
        return null;
    } catch (error) {
        console.error(`Failed to load or parse "${key}" from localStorage:`, error);
        localStorage.removeItem(key);
        return null;
    }
}

/**
 * Сохраняет данные в localStorage.
 * @param key - ключ в localStorage
 * @param data - данные для сохранения
 */
export function saveToStorage<T>(key: string, data: T): void {
    try {
        localStorage.setItem(key, JSON.stringify(data));
    } catch (error) {
        console.error(`Failed to save "${key}" to localStorage:`, error);
    }
}