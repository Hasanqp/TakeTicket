using System.Diagnostics;
using TakeTicket.Domain;

namespace TakeTicket.Application.Messaging
{
    public class WhatsAppSender : IMessageSender
    {
        public async Task SendAsync(string message, Customers customer, string? attachmentPath = null)
        {
            string phone = customer.PhoneNumber.Replace("+", "");

            string url = $"https://web.whatsapp.com/send?phone={phone}&text={Uri.EscapeDataString(message)}";


            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            // Open the Ticket Auto
            if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = attachmentPath,
                    UseShellExecute = true
                });
            }

            await Task.CompletedTask;
        }
    }
}
