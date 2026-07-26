using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TakeTicket.Data.SqlServer;

namespace TakeTicket.Tests.Helpers
{
    public static class TestDbContextFactory
    {
        public static DBContext Create()
        {
            var connection =
                new SqliteConnection("Filename=:memory:");

            connection.Open();

            var options =
                new DbContextOptionsBuilder<DBContext>()
                .UseSqlite(connection)
                .Options;

            var context = new DBContext(options);

            context.Database.EnsureCreated();

            return context;
        }
    }
}
