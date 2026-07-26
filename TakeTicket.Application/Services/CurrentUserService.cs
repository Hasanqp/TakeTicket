using TakeTicket.Application.Common.Interfaces;

namespace TakeTicket.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
