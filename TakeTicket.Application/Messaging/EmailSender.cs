using TakeTicket.Domain;

namespace TakeTicket.Application.Messaging
{
    public class EmailSender : IMessageSender
    {
        public async Task SendAsync(string message, Customers customer, string? attachmentPath = null)
        {
            throw new NotImplementedException("Email not implemented yet.");
        }
    }
}
