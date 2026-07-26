using Moq;
using TakeTicket.Application.Services;
using TakeTicket.Domain;
using TakeTicket.Domain.Repositories;

namespace TakeTicket.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock =
                new Mock<IUserRepository>();

            _userService =
                new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetByUserNameAsync_ShouldReturnUser()
        {
            // Arrange
            var user = new Users
            {
                Id = 1,
                UserName = "admin",
                FullName = "Administrator"
            };

            _userRepositoryMock
                .Setup(x => x.GetByUserNameAsync("admin"))
                .ReturnsAsync(user);

            // Act
            var result =
                await _userService.GetByUserNameAsync("admin");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("admin", result.UserName);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepository()
        {
            // Arrange
            var user = new Users
            {
                Id = 1,
                UserName = "admin"
            };

            // Act
            await _userService.UpdateAsync(user);

            // Assert
            _userRepositoryMock.Verify(
                x => x.UpdateAsync(user),
                Times.Once);
        }
    }
}
