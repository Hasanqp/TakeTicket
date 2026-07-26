using TakeTicket.Domain;
using TakeTicket.Domain.Constants;
using TakeTicket.Domain.Enums;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Paths;

namespace TakeTicket.Application.Services
{
    public class TemplateService
    {
        private readonly string _templatePath;

        public TemplateService()
        {
            _templatePath = Path.Combine(
                AppPaths.AppDataFolder,
                "Messaging",
                "Templates");

            if (!Directory.Exists(_templatePath))
            {
                Directory.CreateDirectory(_templatePath);
            }

            EnsureDefaultTemplates();
        }

        public string GetMessage(Customers customer, MessageType type)
        {
            if (!Enum.IsDefined(typeof(MessageType), type))
                throw new Exception($"Invalid message type: {type}");

            string lang = ResolveLanguage(customer.Nationality);

            string fileName = type switch
            {
                MessageType.Registration => $"{lang}Registration.txt",
                MessageType.Confirmation => $"{lang}Confirmation.txt",
                _ => throw new Exception("Unknown message type")
            };

            string fullPath = Path.Combine(_templatePath, fileName);

            if (!File.Exists(fullPath))

                throw new Exception("Template not found: " + fullPath);

            string content = File.ReadAllText(fullPath);

            return content
                .Replace("{Name}", customer.Name ?? string.Empty)
                .Replace("{StartDate}", customer.StartDate.ToString("yyyy/MM/dd"))
                .Replace("{FinishDate}", customer.FinishDate.ToString("yyyy/MM/dd"));
        }

        private string ResolveLanguage(string nationality)
        {
            if (string.IsNullOrWhiteSpace(nationality))
                return "English";

            nationality = nationality.Trim();

            if (NationalityConstants.ArabicCountries
                .Contains(nationality))
            {
                return "Arabic";
            }

            if (NationalityConstants.RussianSpeakingCountries
                .Contains(nationality))
            {
                return "Russian";
            }

            return "English";
        }

        private void EnsureDefaultTemplates()
        {
            CreateIfMissing(
                "ArabicRegistration.txt",
                @"السلام عليكم {Name} 🌿

تم تسجيل حجز الرحلة الخاص بكم بنجاح.

تاريخ الذهاب: {StartDate}
تاريخ العودة: {FinishDate}

نسعد بخدمتكم 🌸");

            CreateIfMissing(
                "ArabicConfirmation.txt",
        @"السلام عليكم {Name} 🌿

نذكركم بأن موعد رحلتكم سيكون بتاريخ {StartDate}.

يرجى الرد على هذه الرسالة لتأكيد الرحلة.

نتمنى لكم رحلة سعيدة 🌸");

            CreateIfMissing(
                "EnglishRegistration.txt",
        @"Hello Dear {Name}

Your trip booking has been successfully registered.

Trip Start: {StartDate}
Trip End: {FinishDate}

We are happy to serve you 🌸");

            CreateIfMissing(
                "EnglishConfirmation.txt",
        @"Hello Dear {Name}

This is a reminder that your trip starts on {StartDate}.

Have a blessed journey 🌸");

            CreateIfMissing(
    "RussianRegistration.txt",
@"Здравствуйте, уважаемый(ая) {Name}!

Ваше бронирование поездки успешно зарегистрировано.

Начало поездки: {StartDate}
Окончание поездки: {FinishDate}

Мы рады быть к Вашим услугам! 🌸");

            CreateIfMissing(
                "RussianConfirmation.txt",
            @"Здравствуйте, уважаемый(ая) {Name},

Напоминаем, что ваше путешествие начинается {StartDate}.

Желаем вам благословенного пути! 🌸");
        }

        private void CreateIfMissing(string fileName, string content)
        {
            var path = Path.Combine(_templatePath, fileName);

            if (!File.Exists(path))
            {
                File.WriteAllText(path, content);
            }
        }
    }
}
