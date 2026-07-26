using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using TakeTicket.Infrastructure;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Data.SqlServer;
using TakeTicket.DependencyInjection;
using TakeTicket.Gui.SettingsGui;
using TakeTicket.Gui.UsersGui;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket
{
    public static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (!Properties.Settings.Default.DatabaseConfigured)
            {
                ServiceProvider = Bootstrapper.Configure();

                var settingsForm = ServiceProvider.GetRequiredService<SettingsForm>();

                settingsForm.SetFirstStart(true);

                System.Windows.Forms.Application.Run(settingsForm);

                return;
            }

            var culture =
                Properties.Settings.Default.Language ?? "en";

            Thread.CurrentThread.CurrentCulture =
                new CultureInfo(culture);

            Thread.CurrentThread.CurrentUICulture =
                new CultureInfo(culture);

            System.Windows.Forms.Application.ThreadException += (sender, args) =>
            {
                Logger.Log(args.Exception, "UI Thread");
                MessageCollections.ShowErrorServer();
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var ex = args.ExceptionObject as Exception;

                if (ex != null)
                {
                    Logger.Log(ex, "Non-UI Thread");
                }
            };

            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            string con = string.Empty;

            try
            {
                con = SecureSettingsHelper.Unprotect(Properties.Settings.Default.SqlServerString);
            }
            catch
            {
                MessageBox.Show(MessagesLocal.ConnectionStringInvalid);

                ServiceProvider = Bootstrapper.Configure();

                System.Windows.Forms.Application.Run(
                    ServiceProvider.GetRequiredService<SettingsForm>());

                return;
            }

            if (string.IsNullOrWhiteSpace(con))
            {
                ServiceProvider = Bootstrapper.Configure();
                System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<SettingsForm>());
                return;
            }

            try
            {
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Database Connection");

                MessageBox.Show(MessagesLocal.DbConnectionFailed);

                ServiceProvider = Bootstrapper.Configure();
                System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<SettingsForm>());
                return;
            }

            ServiceProvider = Bootstrapper.Configure();

            var language = Properties.Settings.Default.Language;

            if (string.IsNullOrWhiteSpace(language))
            {
                language = "en";
            }

            LanguageManager.SetLanguage(language); //test

            //System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<LoginUserForm>());

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DBContext>();
                context.Database.Migrate();
            }

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DBContext>();

                bool hasUsers = context.Users.Any();

                if (!hasUsers)
                {
                    System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<AddUserForm>());
                    return;
                }
            }

            System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<StartForm>());
        }
    }
}
