using Microsoft.EntityFrameworkCore;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Domain;
using TakeTicket.Domain.Enums;
using TakeTicket.Data;
using TakeTicket.Data.SqlServer;
using TakeTicket.Shared;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Application.Services
{
    public class CustomerService
    {
        private readonly IDataHelper<Customers> _customerDataHelper;
        private readonly IDataHelper<SystemRecords> _systemRecordsHelper;
        private readonly IMessagingService _messagingService;
        private readonly IDataHelper<Buses> _busDataHelper;
        private readonly ICurrentUserService _currentUserService;
        private readonly DBContext _context;

        public CustomerService(IDataHelper<Customers> customerdataHelper, IDataHelper<SystemRecords> systemRecordsHelper, IDataHelper<Buses> busesdataHelper, ICurrentUserService currentUserService, IMessagingService messagingService, DBContext context)
        {
            _customerDataHelper = customerdataHelper;
            _busDataHelper = busesdataHelper;
            _systemRecordsHelper = systemRecordsHelper;

            _messagingService = messagingService;

            _currentUserService = currentUserService;

            _context = context;
        }

        public async Task<int> AddCustomerAsync(Customers customer, string userName)
        {
           
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new ValidationException(_localizer.Get("NameRequired"));

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                throw new ValidationException(_localizer.Get("PhoneRequired"));

            customer.CreatedByUserId = _currentUserService.UserId;
            customer.AddedDate = DateTime.Now;


            using var transaction = await _context.Database.BeginTransactionAsync(
                System.Data.IsolationLevel.Serializable);

            try
            {
                if (customer.BusId.HasValue)
                {
                    var bus = await _context.Buses
                        .FirstOrDefaultAsync(x => x.Id == customer.BusId.Value);

                    if (bus == null)
                        throw new ValidationException(_localizer.Get("BusNotFound"));

                    int mainCount = await _context.Customers.CountAsync(x =>
                        x.BusId == customer.BusId &&
                        x.ReservationType == ReservationType.Main);

                    int reserveCount = await _context.Customers.CountAsync(x =>
                        x.BusId == customer.BusId &&
                        x.ReservationType == ReservationType.Reserve);

                    if (customer.ReservationType == ReservationType.Main &&
                        mainCount >= bus.Capacity)
                    {
                        throw new ValidationException(_localizer.Get("BusFull"));
                    }

                    if (customer.ReservationType == ReservationType.Reserve &&
                        reserveCount >= bus.ExtraCapacity)
                    {
                        throw new ValidationException(_localizer.Get("ReserveFull"));
                    }
                }

                await _context.Customers.AddAsync(customer);

                await _context.SaveChangesAsync();

                var record = new SystemRecords
                {
                    Title = _localizer.Get("LogAddTitle"),
                    UserName = userName,
                    Details = $"{_localizer.Get("LogAddDetail")} {customer.Name}",
                    AddedDate = DateTime.Now
                };

                await _context.SystemRecords.AddAsync(record);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return 1;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Customers>> GetAllAsync()
        {
            return await _customerDataHelper.GetAllDataAsync();
        }

        public async Task<Customers?> GetByIdAsync(int id)
        {
            return await _customerDataHelper.FindAsync(id);
        }

        public async Task<int> UpdateCustomerAsync(Customers customers, string userName)
        {
            if (customers.Id == 0)
                throw new ValidationException(_localizer.Get("InvalidCustomer"));

            if (string.IsNullOrWhiteSpace(customers.Name))
                throw new ValidationException(_localizer.Get("NameRequired"));

            var oldCustomer = await _customerDataHelper.FindAsync(customers.Id);

            if (oldCustomer == null)
                throw new ValidationException(_localizer.Get("CustomerNotFound"));

            bool busChanged =
                oldCustomer.BusId != customers.BusId;

            bool reservationChanged =
                oldCustomer.ReservationType != customers.ReservationType;

            if ((busChanged || reservationChanged) && customers.BusId.HasValue)
            {
                var bus = await _context.Buses
                    .FirstOrDefaultAsync(x => x.Id == customers.BusId.Value);

                if (bus == null)
                    throw new ValidationException(_localizer.Get("BusNotFound"));

                int mainCount = await _context.Customers.CountAsync(x =>
                    x.BusId == customers.BusId &&
                    x.Id != customers.Id &&
                    x.ReservationType == ReservationType.Main);

                int reserveCount = await _context.Customers.CountAsync(x =>
                    x.BusId == customers.BusId &&
                    x.Id != customers.Id &&
                    x.ReservationType == ReservationType.Reserve);

                if (customers.ReservationType == ReservationType.Main &&
                    mainCount >= bus.Capacity)
                {
                    throw new ValidationException(_localizer.Get("BusFull"));
                }

                if (customers.ReservationType == ReservationType.Reserve &&
                    reserveCount >= bus.ExtraCapacity)
                {
                    throw new ValidationException(_localizer.Get("ReserveFull"));
                }
            }

            var result = await _customerDataHelper.EditAsync(customers);

            if (result == 1)
            {
                var record = new SystemRecords
                {
                    Title = _localizer.Get("LogEditTitle"),
                    UserName = userName,
                    Details = $"{_localizer.Get("LogEditDetail")} {customers.Name}",
                    AddedDate = DateTime.Now
                };

                await _systemRecordsHelper.AddAsync(record);
            }

            return result;
        }

        public async Task<int> DeleteCustomerAsync(int id, string userName)
        {
            var customer = await _customerDataHelper.FindAsync(id);

            if (customer == null)
                throw new ValidationException(_localizer.Get("CustomerNotFound"));
            var result = await _customerDataHelper.DeleteAsync(id);

            if (result == 1)
            {
                var record = new SystemRecords
                {
                    Title = _localizer.Get("LogDeleteTitle"),
                    UserName = userName,
                    Details = $"{_localizer.Get("LogDeleteDetail")} {customer.Name}",
                    AddedDate = DateTime.Now
                };

                await _systemRecordsHelper.AddAsync(record);
            }

            return result;
        }

        public async Task<List<Customers>> SearchAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return await _customerDataHelper.GetAllDataAsync();

            return await _customerDataHelper.SearchAsync(searchText);
        }
        public async Task SendMessageAsync(int customerId, MessageType type)
        {
            var customer = await _customerDataHelper.FindAsync(customerId);

            if (customer == null)
                throw new ValidationException(_localizer.Get("CustomerNotFound"));

            bool canSendConfirmation =
                customer.RegistrationMessageSent;

            if (type == MessageType.Confirmation &&
                !canSendConfirmation)
            {
                throw new ValidationException(_localizer.Get("CannotSendConfirmation"));
            }

            if (type == MessageType.Registration && customer.RegistrationMessageSent)
            {
                throw new ValidationException(_localizer.Get("RegistrationAlreadySent"));
            }

            await _messagingService.SendAsync(customer, type);

            if (type == MessageType.Registration)
                customer.RegistrationMessageSent = true;

            if (type == MessageType.Confirmation)
                customer.ConfirmationMessageSent = true;

            await _customerDataHelper.EditAsync(customer);
        }

        public async Task CheckUpcomingTripsAsync()
        {
            var customers = await _customerDataHelper.GetAllDataAsync();

            var upcomingCustomers = customers
                .Where(x =>
                    x.RegistrationMessageSent &&
                    x.StartDate.Date == DateTime.Today.AddDays(2) &&
                   !x.ConfirmationMessageSent &&
                    (x.ConfirmationAutoSentDate == null ||
                    x.ConfirmationAutoSentDate.Value.Date != DateTime.Today))
                .ToList();

            foreach (var customer in upcomingCustomers)
            {
                await SendMessageAsync(customer.Id, MessageType.Confirmation);

                customer.ConfirmationAutoSentDate = DateTime.Today;

                await _customerDataHelper.EditAsync(customer);
            }
        }

        private readonly Localizer _localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Services.CustomerServiceLocal.CustomerServiceLocal");
    }
}
