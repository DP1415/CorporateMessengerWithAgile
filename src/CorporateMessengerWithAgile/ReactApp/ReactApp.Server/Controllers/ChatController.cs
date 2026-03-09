using Application.Dto.Summary;
using Application.Entity.Chats.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class ChatController(ISender sender) : BaseController(sender)
    {
        [HttpGet("{userId}/chats")]
        public async Task<IEnumerable<ChatSummaryDto>> GetChatsByUserId(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new ChatGetByUserId(userId), cancellationToken);
    }

    public class ChatHub : Hub
    {
        // Метод, который клиент будет вызывать для отправки сообщения
        public async Task SendMessage(string userId, string message)
        {
            // Отправляем сообщение всем подключенным клиентам (или можно конкретному пользователю)
            // "ReceiveMessage" — это имя метода, который будет вызван у клиента
            await Clients.All.SendAsync("ReceiveMessage", userId, message);
            
            // Если нужно отправить только конкретному пользователю (по UserId):
            // await Clients.User(userId).SendAsync("ReceiveMessage", userId, message);
        }

        // Можно перехватывать события подключения/отключения
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // Логика при подключении (например, добавить в группу чата)
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
            // Логика при отключении
        }

    }
}
