// src/controllers/ChatController.ts
import type { AuthController } from ".";
import type { Guid, Result } from "../models";
import { ChatSummaryDtoSchema, type ChatSummaryDto } from "../models/entity/ChatSummaryDto";
import { AuthenticatedController } from "./abstract/AuthenticatedController";

export class ChatController extends AuthenticatedController {
    constructor(authController: AuthController) { super(authController, '/Chat'); }

    async GetChatsByUserId(userId: Guid): Promise<Result<ChatSummaryDto[]>> {
        const result = await this.request('GET', `/${userId}/chats`);
        if (result.isFailure) return result as Result<ChatSummaryDto[]>;
        return this.convertToArray<ChatSummaryDto>(result.value, ChatSummaryDtoSchema);
    }
}