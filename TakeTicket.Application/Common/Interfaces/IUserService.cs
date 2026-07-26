
using TakeTicket.Domain;

namespace TakeTicket.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<Users> GetByUserNameAsync(string userName);
        Task UpdateAsync(Users user);
    }
}
