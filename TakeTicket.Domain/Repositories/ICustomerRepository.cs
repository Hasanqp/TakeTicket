using System.Collections.Generic;
using System.Threading.Tasks;

namespace TakeTicket.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetByBusIdAsync(int busId);
    }
}
