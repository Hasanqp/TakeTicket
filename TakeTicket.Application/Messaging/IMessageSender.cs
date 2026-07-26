using TakeTicket.Domain;

namespace TakeTicket.Application.Messaging
{
    public interface IMessageSender
    {
        Task SendAsync(string message, Customers customer, string? attachmentPath = null);
    }
}
