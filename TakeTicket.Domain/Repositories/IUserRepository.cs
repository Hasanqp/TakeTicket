using System.Threading.Tasks;

namespace TakeTicket.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Users> GetByUserNameAsync(string userName);
        Task UpdateAsync(Users user);
    }
}
