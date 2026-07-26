using TakeTicket.Domain.Enums;

namespace TakeTicket.Application.Messaging
{
    public class MessageRequest
    {
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Language { get; set; }
        public MessageType Type { get; set; }
    }
}
