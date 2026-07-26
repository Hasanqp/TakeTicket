namespace TakeTicket.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
