using Moq;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Services;
using TakeTicket.Domain;
using TakeTicket.Domain.Enums;
using TakeTicket.Domain.Repositories;
using TakeTicket.Data;
using TakeTicket.Shared;
using TakeTicket.Tests.Helpers;

namespace TakeTicket.Tests
{
    public class BusServiceTests
    {
        private BusService CreateBusService(
            Mock<IDataHelper<Customers>>? customerMock = null,
            Mock<IBusRepository>? busRepositoryMock = null)
        {
            var busDataHelperMock =
                new Mock<IDataHelper<Buses>>();

            customerMock ??=
                new Mock<IDataHelper<Customers>>();

            busRepositoryMock ??=
                new Mock<IBusRepository>();

            return new BusService(
                busDataHelperMock.Object,
                customerMock.Object,
                busRepositoryMock.Object
            );
        }

        [Fact]
        public async Task DeleteBus_ShouldReturnMinusOne_WhenBusHasCustomers()
        {
            var customerMock =
                new Mock<IDataHelper<Customers>>();

            customerMock
                .Setup(x => x.GetAllDataAsync())
                .ReturnsAsync(new List<Customers>
                {
            new Customers
            {
                Id = 1,
                BusId = 5
            }
                });

            var service = CreateBusService(customerMock);

            var result = await service.DeleteBusAsync(5);

            Assert.Equal(-1, result);
        }

        [Fact]
        public async Task GetPassengerCount_ShouldReturnCorrectCount()
        {
            var customerMock =
                new Mock<IDataHelper<Customers>>();

            customerMock
                .Setup(x => x.GetAllDataAsync())
                .ReturnsAsync(new List<Customers>
                {
                    new Customers { BusId = 1 },
                    new Customers { BusId = 1 },
                    new Customers { BusId = 2 }
                });

            var service = CreateBusService(customerMock);

            var result = await service.GetPassengerCountAsync(1);

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetMainPassengerCount_ShouldReturnCorrectCount()
        {
            var customerMock =
                new Mock<IDataHelper<Customers>>();

            customerMock
                .Setup(x => x.GetAllDataAsync())
                .ReturnsAsync(new List<Customers>
                {
            new Customers
            {
                BusId = 1,
                ReservationType = ReservationType.Main
            },
            new Customers
            {
                BusId = 1,
                ReservationType = ReservationType.Reserve
            },
            new Customers
            {
                BusId = 1,
                ReservationType = ReservationType.Main
            }
                });

            var service = CreateBusService(customerMock);

            var result = await service.GetMainPassengerCountAsync(1);

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task IsBusNumberExists_ShouldReturnTrue()
        {
            var busRepositoryMock =
                new Mock<IBusRepository>();

            busRepositoryMock
                .Setup(x => x.IsBusNumberExists("BUS-1", null))
                .ReturnsAsync(true);

            var service =
                CreateBusService(null, busRepositoryMock);

            var result =
                await service.IsBusNumberExists("BUS-1");

            Assert.True(result);
        }
    }
}
