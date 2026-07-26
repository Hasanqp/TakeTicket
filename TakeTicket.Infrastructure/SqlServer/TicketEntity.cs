using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeTicket.Domain;
using TakeTicket.Domain.Repositories;
using TakeTicket.Shared.Common.Logging;

namespace TakeTicket.Data.SqlServer
{
    public class TicketEntity : IDataHelper<Ticket>, ITicketRepository
    {
        private readonly DBContext db;
        private Ticket table;

        public TicketEntity(DBContext context)
        {
            db = context;
        }

        public int Add(Ticket table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.Tickets.Add(table);
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.Add");
                return 0;
            }
        }

        public async Task<int> AddAsync(Ticket table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await db.Tickets.AddAsync(table);
                    await db.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.AddAsync");
                return 0;
            }
        }

        public int Delete(int Id)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    table = Find(Id);
                    db.Tickets.Remove(table);
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.Delete");
                return 0;
            }
        }

        public async Task<int> DeleteAsync(int Id)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    table = await FindAsync(Id);
                    db.Tickets.Remove(table);
                    await db.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.DeleteAsync");
                return 0;
            }
        }

        public int Edit(Ticket table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.Tickets.Update(table);
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.Edit");
                return 0;
            }
        }

        public async Task<int> EditAsync(Ticket table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    db.Tickets.Update(table);
                    await db.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.EditAsync");
                return 0;
            }
        }

        public Ticket Find(int Id)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Tickets.FirstOrDefault(x => x.Id == Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.Find");
                return null;
            }
        }

        public async Task<Ticket> FindAsync(int Id)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Tickets.FirstOrDefaultAsync(x => x.Id == Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.FindAsync");
                return null;
            }
        }

        public List<Ticket> GetAllData()
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Tickets.ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.GetAllData");
                return null;
            }
        }

        public async Task<List<Ticket>> GetAllDataAsync()
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Tickets.ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.GetAllDataAsync");
                return null;
            }
        }

        public async Task<List<Ticket>> GetByCustomerIdAsync(int customerId)
        {
            return await db.Tickets
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public List<Ticket> Search(string SearchItem)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Tickets
                        .Where(x =>
                            x.Id.ToString() == SearchItem ||
                            x.SeatNumber.Contains(SearchItem) ||
                            x.TicketType.Contains(SearchItem)
                        )
                        .ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.Search");
                return null;
            }
        }

        public async Task<List<Ticket>> SearchAsync(string SearchItem)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Tickets
                        .Where(x =>
                            x.Id.ToString() == SearchItem ||
                            x.SeatNumber.Contains(SearchItem) ||
                            x.TicketType.Contains(SearchItem)
                        )
                        .ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "TicketEntity.SearchAsync");
                return null;
            }
        }
    }
}
