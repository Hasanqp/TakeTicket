using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Messaging;
using TakeTicket.Domain;
using TakeTicket.Domain.Enums;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Application.Services
{
    public class MessagingService : IMessagingService
    {
        private readonly TicketService _ticketService;
        private readonly TemplateService _templateService;
        private readonly IMessageSender _sender;

        public MessagingService(IMessageSender sender, TemplateService templateService, TicketService ticketService)
        {
            _sender = sender;
            _templateService = templateService;
            _ticketService = ticketService;
        }

        public async Task SendAsync(Customers customer, MessageType type)
        {
            string? attachment = null;

            var message = await BuildMessageAsync(customer, type);

            if (type == MessageType.Confirmation)
            {
                try
                {
                    attachment = await _ticketService.CreateFullTicketAsync(customer);

                    message += $"\n\n🎫 {_localizer.Get("TicketAttached")}";
                }
                catch (Exception)
                {
                    message += $"\n\n🎫 {_localizer.Get("TicketAlreadyExists")}";
                }
            }

            await _sender.SendAsync(message, customer, attachment);
        }

        public Task<string> BuildMessageAsync(Customers customer, MessageType type)
        {
            var message = _templateService.GetMessage(customer, type);
            return Task.FromResult(message);
        }

        private readonly Localizer _localizer = new Localizer("TakeTicket.Shared.Localization.Services.MessagingServiceLocal.MessagingServiceLocal");
    }
}
