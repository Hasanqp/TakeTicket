using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Domain;
using TakeTicket.Domain.Repositories;

namespace TakeTicket.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Users> GetByUserNameAsync(string userName)
        {
            return await this.userRepository.GetByUserNameAsync(userName);
        }

        public async Task UpdateAsync(Users user)
        {
            await this.userRepository.UpdateAsync(user);
        }
    }
}
