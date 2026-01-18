// src/models/Guid.ts
import { z } from 'zod';

export type Guid = string;

const UUID_V4_REGEX = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

export const GuidSchema = z.string().regex(UUID_V4_REGEX, {
    message: "Invalid GUID format",
});

///**
// * Генерация нового GUID (если нужно на фронтенде)
// */
//export const newGuid = (): Guid => {
//    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
//        const r = (Math.random() * 16) | 0;
//        const v = c === 'x' ? r : (r & 0x3) | 0x8;
//        return v.toString(16);
//    });
//};