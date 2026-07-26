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
    public class CustomersEntity : IDataHelper<Customers>, ICustomerRepository
    {
        // Variables
        private readonly DBContext db;
        private Customers table;
        // Constructors
        public CustomersEntity(DBContext context)
        {
            db = context;
        }

        public int Add(Customers table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.Customers.Add(table);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.Add");
                return 0;
            }
        }

        public async Task<int> AddAsync(Customers table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await db.Customers.AddAsync(table);
                    await db.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.AddAsync");
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
                    db.Customers.Remove(table);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.Delete");
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
                    await Task.Run(() => db.Customers.Remove(table));
                    await db.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.DeleteAsync");
                return 0;
            }
        }

        public int Edit(Customers table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.Customers.Update(table);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.Edit");
                return 0;
            }
        }

        public async Task<int> EditAsync(Customers table)
        {
            try
            {
                if (!await db.Database.CanConnectAsync())
                    return 0;

                var customer = db.Customers.Local
                    .FirstOrDefault(x => x.Id == table.Id);

                customer ??= await db.Customers.FindAsync(table.Id);

                if (customer == null)
                    return 0;

                db.Entry(customer).CurrentValues.SetValues(table);

                await db.SaveChangesAsync();

                return 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.EditAsync");
                return 0;
            }
        }

        public Customers Find(int Id)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Customers.Where(x => x.Id == Id).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.Find");
                return null;
            }
        }

        public async Task<Customers> FindAsync(int Id)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Customers.FirstOrDefaultAsync(x => x.Id == Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.FindAsync");
                return null;
            }
        }

        public List<Customers> GetAllData()
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Customers.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.GetAllData");
                return null;
            }
        }

        public async Task<List<Customers>> GetAllDataAsync()
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Customers.ToListAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.GetAllDataAsync");
                return null;
            }
        }

        public List<Customers> Search(string SearchItem)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Customers.Where(x => x.Id.ToString() == SearchItem
                    || x.Name.Contains(SearchItem)
                    || x.Nationality.Contains(SearchItem)
                    || x.Passport.Contains(SearchItem)
                    || x.PhoneNumber.Contains(SearchItem)
                    || x.StartDate.Date.ToString().Contains(SearchItem)
                    || x.FinishDate.Date.ToString().Contains(SearchItem)
                    || x.TripType.Contains(SearchItem)
                    || x.Address.Contains(SearchItem)
                    || x.Details.Contains(SearchItem)
                    || x.AddedDate.Date.ToString().Contains(SearchItem)
                    )
                        .ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.Search");

                return null;
            }
        }

        public async Task<List<Customers>> SearchAsync(string SearchItem)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Customers.Where(x => x.Id.ToString() == SearchItem
                    || x.Name.Contains(SearchItem)
                    || x.Nationality.Contains(SearchItem)
                    || x.Passport.Contains(SearchItem)
                    || x.PhoneNumber.Contains(SearchItem)
                    || x.StartDate.Date.ToString().Contains(SearchItem)
                    || x.FinishDate.Date.ToString().Contains(SearchItem)
                    || x.TripType.Contains(SearchItem)
                    || x.Address.Contains(SearchItem)
                    || x.Details.Contains(SearchItem)
                    || x.AddedDate.Date.ToString().Contains(SearchItem)
                    ).ToListAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "CustomersEntity.SearchAsync");
                return null;
            }
        }

        public async Task<List<Customers>> GetByBusIdAsync(int busId)
        {
            return await db.Customers
                .Where(c => c.BusId == busId)
                .ToListAsync();
        }
    }
}
