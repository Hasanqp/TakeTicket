using TakeTicket.Infrastructure;

namespace TakeTicket.Tests
{
    public class SecureSettingsHelperTests
    {
        [Fact]
        public void Protect_ShouldReturnEncryptedText()
        {
            // Arrange
            var text = "Hello";

            // Act
            var encrypted =
                SecureSettingsHelper.Protect(text);

            // Assert
            Assert.NotEqual(text, encrypted);
        }

        [Fact]
        public void Unprotect_ShouldReturnOriginalText()
        {
            // Arrange
            var text = "SensitiveData";

            var encrypted =
                SecureSettingsHelper.Protect(text);

            // Act
            var result =
                SecureSettingsHelper.Unprotect(encrypted);

            // Assert
            Assert.Equal(text, result);
        }

        [Fact]
        public void Protect_ShouldReturnEmpty_WhenTextNull()
        {
            var result =
                SecureSettingsHelper.Protect(null);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Unprotect_ShouldReturnEmpty_WhenTextNull()
        {
            var result =
                SecureSettingsHelper.Unprotect(null);

            Assert.Equal(string.Empty, result);
        }
    }
}
