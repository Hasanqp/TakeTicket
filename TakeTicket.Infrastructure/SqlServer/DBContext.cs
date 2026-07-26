using Microsoft.EntityFrameworkCore;
using TakeTicket.Domain;

namespace TakeTicket.Data.SqlServer
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<Buses> Buses { get; set; }
        public DbSet<SystemRecords> SystemRecords { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
