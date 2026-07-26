using System.Threading.Tasks;

namespace TakeTicket.Domain.Repositories
{
    public interface IBusRepository
    {
        Task<bool> IsBusNumberExists(string busNumber, int? excludeId = null);
        Task<bool> IsBusNoExists(int busNo, int? excludeId = null);
    }
}
