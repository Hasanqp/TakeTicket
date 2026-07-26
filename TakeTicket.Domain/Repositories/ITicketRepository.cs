using System.Collections.Generic;
using System.Threading.Tasks;

namespace TakeTicket.Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetByCustomerIdAsync(int customerId);
    }
}
