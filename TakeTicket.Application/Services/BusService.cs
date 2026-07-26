using TakeTicket.Domain;
using TakeTicket.Domain.Enums;
using TakeTicket.Domain.Repositories;
using TakeTicket.Data;

namespace TakeTicket.Application.Services
{
    public class BusService
    {
        private readonly IDataHelper<Buses> _busDataHelper;
        private readonly IDataHelper<Customers> _customerDataHelper;
        private readonly IBusRepository _busRepository;

        public BusService(
            IDataHelper<Buses> busDataHelper,
            IDataHelper<Customers> customerDataHelper,
            IBusRepository busRepository)
        {
            _busDataHelper = busDataHelper;
            _customerDataHelper = customerDataHelper;
            _busRepository = busRepository;
        }

        public async Task<int> DeleteBusAsync(int busId)
        {
            var customers = await _customerDataHelper.GetAllDataAsync();

            bool hasPassengers = customers.Any(c => c.BusId == busId);

            if (hasPassengers)
                return -1; // Cannot delete bus with passengers

            return await _busDataHelper.DeleteAsync(busId);
        }

        public async Task<int> GetPassengerCountAsync(int busId)
        {
            var customers = await _customerDataHelper.GetAllDataAsync();
            return customers.Count(c => c.BusId == busId);
        }

        public async Task<int> GetMainPassengerCountAsync(int busId)
        {
            var customers = await _customerDataHelper.GetAllDataAsync();
            return customers.Count(c => c.BusId == busId && c.ReservationType == ReservationType.Main);
        }

        public async Task<int> GetReservePassengerCountAsync(int busId)
        {
            var customers = await _customerDataHelper.GetAllDataAsync();
            return customers.Count(c => c.BusId == busId && c.ReservationType == ReservationType.Reserve);
        }

        public async Task<Dictionary<int, (int main, int reserve)>> GetPassengerCountsForAllBusesAsync()
        {
            var customers = await _customerDataHelper.GetAllDataAsync();

            var result = customers
                .Where(c => c.BusId != null)
                .GroupBy(c => c.BusId.Value)
                .ToDictionary(
                    g => g.Key,
                    g => (
                        main: g.Count(c => c.ReservationType == ReservationType.Main),
                        reserve: g.Count(c => c.ReservationType == ReservationType.Reserve)
                    )
                );

            return result;
        }

        public async Task<bool> IsBusNumberExists(string busNumber, int? excludeId = null)
        {
            return await _busRepository.IsBusNumberExists(busNumber, excludeId);
        }

        public async Task<bool> IsBusNoExists(int busNo, int excludeId = 0)
        {
            return await _busRepository.IsBusNoExists(busNo, excludeId);
        }
    }
}
