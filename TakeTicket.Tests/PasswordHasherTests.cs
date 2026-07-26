using TakeTicket.Application.Common.Security;

namespace TakeTicket.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void Hash_ShouldReturnDifferentValue()
        {
            // Arrange
            var password = "1234";

            // Act
            var hash =
                PasswordHasher.Hash(password);

            // Assert
            Assert.NotEqual(password, hash);
        }

        [Fact]
        public void Verify_ShouldReturnTrue_WhenPasswordCorrect()
        {
            // Arrange
            var password = "1234";

            var hash =
                PasswordHasher.Hash(password);

            // Act
            var result =
                PasswordHasher.Verify(password, hash);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Verify_ShouldReturnFalse_WhenPasswordWrong()
        {
            // Arrange
            var hash =
                PasswordHasher.Hash("1234");

            // Act
            var result =
                PasswordHasher.Verify("wrong", hash);

            // Assert
            Assert.False(result);
        }
    }
}
