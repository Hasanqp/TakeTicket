using System.Globalization;

namespace TakeTicket.Shared.Localization
{
    public static class LanguageManager
    {
        public static void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
