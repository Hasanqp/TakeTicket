using Moq;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Services;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared;
using TakeTicket.Tests.Helpers;

namespace TakeTicket.Tests
{
    public class CustomerServiceTests
    {
        private CustomerService CreateCustomerService()
        {
            var customerDataHelperMock =
                new Mock<IDataHelper<Customers>>();

            var systemRecordsMock =
                new Mock<IDataHelper<SystemRecords>>();

            var busDataHelperMock =
                new Mock<IDataHelper<Buses>>();

            var currentUserServiceMock =
                new Mock<ICurrentUserService>();

            var messagingServiceMock =
                new Mock<IMessagingService>();

            var context = TestDbContextFactory.Create();

            return new CustomerService(
                customerDataHelperMock.Object,
                systemRecordsMock.Object,
                busDataHelperMock.Object,
                currentUserServiceMock.Object,
                messagingServiceMock.Object,
                context
            );
        }

        [Fact]
        public async Task AddCustomer_ShouldThrow_WhenNameIsEmpty()
        {
            // Arrange
            var service = CreateCustomerService();

            var customer = new Customers
            {
                Name = "",
                PhoneNumber = "966555555555"
            };

            // Act + Assert
            await Assert.ThrowsAsync<ValidationException>(() =>
                service.AddCustomerAsync(customer, "admin"));
        }

        [Fact]
        public async Task AddCustomer_ShouldThrow_WhenPhoneIsEmpty()
        {
            // Arrange
            var service = CreateCustomerService();

            var customer = new Customers
            {
                Name = "alix",
                PhoneNumber = ""
            };

            // Act + Assert
            await Assert.ThrowsAsync<ValidationException>(() =>
                service.AddCustomerAsync(customer, "admin"));
        }

        [Fact]
        public async Task AddCustomer_ShouldThrow_WhenBusNotFound()
        {
            var service = CreateCustomerService();

            var customer = new Customers
            {
                Name = "alix",
                PhoneNumber = "966555555555",
                BusId = 1
            };

            await Assert.ThrowsAsync<ValidationException>(() =>
                service.AddCustomerAsync(customer, "admin"));
        }

        [Fact]
        public async Task UpdateCustomer_ShouldThrow_WhenIdIsZero()
        {
            var service = CreateCustomerService();

            var customer = new Customers
            {
                Id = 0,
                Name = "alix"
            };

            await Assert.ThrowsAsync<ValidationException>(() =>
                service.UpdateCustomerAsync(customer, "admin"));
        }

        [Fact]
        public async Task UpdateCustomer_ShouldThrow_WhenNameIsEmpty()
        {
            var service = CreateCustomerService();

            var customer = new Customers
            {
                Id = 1,
                Name = ""
            };

            await Assert.ThrowsAsync<ValidationException>(() =>
                service.UpdateCustomerAsync(customer, "admin"));
        }

        [Fact]
        public async Task DeleteCustomer_ShouldThrow_WhenCustomerNotFound()
        {
            var customerDataHelperMock =
                new Mock<IDataHelper<Customers>>();

            customerDataHelperMock.Setup(x => x.FindAsync(It.IsAny<int>()))
                .ReturnsAsync((Customers?)null);

            var systemRecordsMock =
                new Mock<IDataHelper<SystemRecords>>();

            var busDataHelperMock =
                new Mock<IDataHelper<Buses>>();

            var currentUserServiceMock =
                new Mock<ICurrentUserService>();

            var messagingServiceMock =
                new Mock<IMessagingService>();

            var context = TestDbContextFactory.Create();

            var service = new CustomerService(
                customerDataHelperMock.Object,
                systemRecordsMock.Object,
                busDataHelperMock.Object,
                currentUserServiceMock.Object,
                messagingServiceMock.Object,
                context);

            await Assert.ThrowsAsync<ValidationException>(() =>
                service.DeleteCustomerAsync(1, "admin"));
        }
    }
}
