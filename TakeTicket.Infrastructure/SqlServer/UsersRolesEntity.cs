using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeTicket.Domain;
using TakeTicket.Shared.Common.Logging;

namespace TakeTicket.Data.SqlServer
{
    public class UsersRolesEntity : IDataHelper<UsersRoles>
    {
        // Variables
        private readonly DBContext db;
        private UsersRoles table;
        // Constructors
        public UsersRolesEntity(DBContext context)
        {
            db = context;
        }

        public int Add(UsersRoles table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.UsersRoles.Add(table);
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
                Logger.Log(ex, "UsersRolesEntity.Add");
                return 0;
            }
        }

        public async Task<int> AddAsync(UsersRoles table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await db.UsersRoles.AddAsync(table);
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
                Logger.Log(ex, "UsersRolesEntity.AddAsync");
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
                    db.UsersRoles.Remove(table);
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
                Logger.Log(ex, "UsersRolesEntity.Delete");
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
                    await Task.Run(() => db.UsersRoles.Remove(table));
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
                Logger.Log(ex, "UsersRolesEntity.DeleteAsync");
                return 0;
            }
        }

        public int Edit(UsersRoles table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.UsersRoles.Update(table);
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
                Logger.Log(ex, "UsersRolesEntity.Edit");
                return 0;
            }
        }

        public async Task<int> EditAsync(UsersRoles table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await Task.Run(() => db.UsersRoles.Update(table));
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
                Logger.Log(ex, "UsersRolesEntity.EditAsync");
                return 0;
            }
        }

        public UsersRoles Find(int Id)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.UsersRoles.Where(x => x.Id == Id).First();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersRolesEntity.Find");
                return null;
            }
        }

        public async Task<UsersRoles> FindAsync(int Id)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await Task.Run(() => db.UsersRoles.Where(x => x.Id == Id).First());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersRolesEntity.FindAsync");
                return null;
            }
        }

        public List<UsersRoles> GetAllData()
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.UsersRoles.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersRolesEntity.GetAllData");
                return null;
            }
        }

        public async Task<List<UsersRoles>> GetAllDataAsync()
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await Task.Run(() => db.UsersRoles.ToList());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersRolesEntity.GetAllDataAsync");
                return null;
            }
        }

        public List<UsersRoles> Search(string SearchItem)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.UsersRoles.Where(x => x.Id.ToString() == SearchItem
                    || x.Key.Contains(SearchItem)
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
                Logger.Log(ex, "UsersRolesEntity.Search");
                return null;
            }
        }

        public async Task<List<UsersRoles>> SearchAsync(string SearchItem)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await Task.Run(() => db.UsersRoles.Where(x => x.Id.ToString() == SearchItem
                    || x.Key.Contains(SearchItem)
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
                Logger.Log(ex, "UsersRolesEntity.SearchAsync");
                return null;
            }
        }
    }
}
