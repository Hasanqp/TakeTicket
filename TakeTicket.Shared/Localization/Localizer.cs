using System.Globalization;
using System.Resources;

namespace TakeTicket.Shared.Localization
{
    public class Localizer
    {
        private readonly ResourceManager rm;

        public Localizer(string resourcePath)
        {
            rm = new ResourceManager(
                resourcePath,
                typeof(Localizer).Assembly);
        }

        public string Get(string key)
        {
            return rm.GetString(
                key,
                CultureInfo.CurrentUICulture)
                ?? key;
        }
    }
}
