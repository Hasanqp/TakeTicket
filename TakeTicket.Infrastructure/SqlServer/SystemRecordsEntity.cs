using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeTicket.Domain;
using TakeTicket.Shared.Common.Logging;

namespace TakeTicket.Data.SqlServer
{
    public class SystemRecordsEntity : IDataHelper<SystemRecords>
    {
        // Variables
        private readonly DBContext db;
        private SystemRecords table;

        // Constructors
        public SystemRecordsEntity(DBContext context)
        {
            db = context;
        }

        public int Add(SystemRecords table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.SystemRecords.Add(table);
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
                Logger.Log(ex, "SystemRecordsEntity.Add");
                return 0;
            }
        }

        public async Task<int> AddAsync(SystemRecords table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await db.SystemRecords.AddAsync(table);
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
                Logger.Log(ex, "SystemRecordsEntity.AddAsync");
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
                    db.SystemRecords.Remove(table);
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
                Logger.Log(ex, "SystemRecordsEntity.Delete");
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
                    await Task.Run(() => db.SystemRecords.Remove(table));
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
                Logger.Log(ex, "SystemRecordsEntity.DeleteAsync");
                return 0;
            }
        }

        public int Edit(SystemRecords table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.SystemRecords.Update(table);
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
                Logger.Log(ex, "SystemRecordsEntity.Edit");
                return 0;
            }
        }

        public async Task<int> EditAsync(SystemRecords table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await Task.Run(() => db.SystemRecords.Update(table));
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
                Logger.Log(ex, "SystemRecordsEntity.EditAsync");
                return 0;
            }
        }

        public SystemRecords Find(int Id)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.SystemRecords.Where(x => x.Id == Id).First();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SystemRecordsEntity.Find");
                return null;
            }
        }

        public async Task<SystemRecords> FindAsync(int Id)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await Task.Run(() => db.SystemRecords.Where(x => x.Id == Id).First());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SystemRecordsEntity.FindAsync");
                return null;
            }
        }

        public List<SystemRecords> GetAllData()
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.SystemRecords.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SystemRecordsEntity.GetAllData");
                return null;
            }
        }

        public async Task<List<SystemRecords>> GetAllDataAsync()
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await Task.Run(() => db.SystemRecords.ToList());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SystemRecordsEntity.GetAllDataAsync");
                return null;
            }
        }

        public List<SystemRecords> Search(string SearchItem)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.SystemRecords.Where(x => x.Id.ToString() == SearchItem
                    || x.UserName.Contains(SearchItem)
                    || x.Title.Contains(SearchItem)
                    || x.Details.ToString().Contains(SearchItem)
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
                Logger.Log(ex, "SystemRecordsEntity.Search");

                return null;
            }
        }

        public async Task<List<SystemRecords>> SearchAsync(string SearchItem)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await Task.Run(() => db.SystemRecords.Where(x => x.Id.ToString() == SearchItem
                    || x.UserName.Contains(SearchItem)
                    || x.Details.Contains(SearchItem)
                    || x.Title.ToString().Contains(SearchItem)
                    || x.AddedDate.Date.ToString().Contains(SearchItem)
                    )
                        .ToList());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "SystemRecordsEntity.SearchAsync");
                return null;
            }
        }
    }
}
