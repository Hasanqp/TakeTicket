using System;
using System.Security.Cryptography;
using System.Text;

namespace TakeTicket.Infrastructure
{
    public static class SecureSettingsHelper
    {
        public static string Protect(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            byte[] data = Encoding.UTF8.GetBytes(text);

            byte[] encrypted = ProtectedData.Protect(
                data,
                null,
                DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encrypted);
        }

        public static string Unprotect(string encryptedText)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                return string.Empty;

            try
            {
                byte[] data = Convert.FromBase64String(encryptedText);

                byte[] decrypted = ProtectedData.Unprotect(
                    data,
                    null,
                    DataProtectionScope.CurrentUser);

                return Encoding.UTF8.GetString(decrypted);
            }
            catch
            {
                // value is not encrypted
                return encryptedText;
            }
        }
    }
}
