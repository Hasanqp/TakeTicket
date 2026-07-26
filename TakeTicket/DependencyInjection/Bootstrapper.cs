using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Messaging;
using TakeTicket.Application.Services;
using TakeTicket.Domain;
using TakeTicket.Domain.Repositories;
using TakeTicket.Data;
using TakeTicket.Data.SqlServer;
using TakeTicket.Gui.BusEnrollmentGui;
using TakeTicket.Gui.PassengerEnrollmentGui;
using TakeTicket.Gui.HomeGui;
using TakeTicket.Gui.MessageGui;
using TakeTicket.Gui.SettingsGui;
using TakeTicket.Gui.SystemRecordsGui;
using TakeTicket.Gui.UsersGui;
using TakeTicket.Infrastructure;

namespace TakeTicket.DependencyInjection
{
    public static class Bootstrapper
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            var savedConnection =
                Properties.Settings.Default.SqlServerString;

            var connectionString =
                SecureSettingsHelper.Unprotect(savedConnection);

            // DBContext
            services.AddDbContext<DBContext>(options => 
            options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            // Data Helpers
            services.AddScoped<IDataHelper<Customers>, CustomersEntity>();
            services.AddScoped<ICustomerRepository, CustomersEntity>();
            services.AddScoped<IDataHelper<SystemRecords>, SystemRecordsEntity>();
            services.AddScoped<IDataHelper<Buses>, BusesEntity>();
            services.AddScoped<IBusRepository, BusesEntity>();
            services.AddScoped<IDataHelper<Users>, UsersEntity>();
            services.AddScoped<IDataHelper<UsersRoles>, UsersRolesEntity>();
            services.AddScoped<IUserRepository, UsersEntity>();
            services.AddScoped<IDataHelper<Ticket>, TicketEntity>();
            services.AddScoped<ITicketRepository, TicketEntity>();

            // Helpers
            services.AddScoped<BackUpRestoreHelper>();

            // Services
            services.AddScoped<CustomerService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<BusService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<TicketService>();

            // Messaging
            services.AddScoped<IMessageSender, WhatsAppSender>();
            services.AddScoped<MessagingService>();
            services.AddScoped<TemplateService>();
            services.AddScoped<IMessagingService, MessagingService>();

            // Forms
            services.AddTransient<StartForm>();
            services.AddTransient<AddBusForm>();
            services.AddTransient<AddPassengerForm>();
            services.AddTransient<LoginUserForm>();
            services.AddTransient<AddUserForm>();
            services.AddTransient<SettingsForm>();
            services.AddTransient<Main>();
            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<RestPasswordForm>();
            services.AddTransient<SendMessageForm>();

            // User Controls
            services.AddTransient<BusUserControl>();
            services.AddTransient<PssengerUserControl>();
            services.AddTransient<HomeUserControl>();
            services.AddTransient<UsersUserControl>();
            services.AddTransient<SystemRecordsUserControl>();

            return services.BuildServiceProvider();
        }
    }
}
