using TakeTicket.Domain;

namespace TakeTicket.Application.Messaging
{
    public class TelegramSender : IMessageSender
    {
        public async Task SendAsync(string message, Customers customer, string? attachmentPath = null)
        {
            throw new NotImplementedException("Telegram not implemented yet.");
        }
    }
}
