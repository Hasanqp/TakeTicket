using TakeTicket.Domain;
using TakeTicket.Domain.Enums;

namespace TakeTicket.Application.Common.Interfaces
{
    public interface IMessagingService
    {
        Task SendAsync(Customers customer, MessageType type);
        Task<string> BuildMessageAsync(Customers customer, MessageType type);
    }
}
