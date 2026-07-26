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
    public class UsersEntity : IDataHelper<Users> , IUserRepository
    {
        // Variables
        private readonly DBContext db;
        // Constructors
        public UsersEntity(DBContext context)
        {
            db = context;
        }

        public int Add(Users table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.Users.Add(table);
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
                Logger.Log(ex, "UsersEntity.Add");
                return 0;
            }
        }

        public async Task<int> AddAsync(Users table)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    await db.Users.AddAsync(table);
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
                Logger.Log(ex, "UsersEntity.AddAsync");
                return 0;
            }
        }

        public int Delete(int Id)
        {
            try
            {
                var entity = db.Users.FirstOrDefault(x => x.Id == Id);

                if (entity == null)
                    return 0;

                db.Users.Remove(entity);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.Delete");
                return 0;
            }
        }

        public async Task<int> DeleteAsync(int Id)
        {
            try
            {
                var entity = await db.Users.FirstOrDefaultAsync(x => x.Id == Id);

                if (entity == null)
                    return 0;

                db.Users.Remove(entity);
                await db.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.DeleteAsync");
                return 0;
            }
        }

        public int Edit(Users table)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    db.Users.Update(table);
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
                Logger.Log(ex, "UsersEntity.Edit");
                return 0;
            }
        }

        public async Task<int> EditAsync(Users table)
        {
            try
            {
                var existing = await db.Users.FirstOrDefaultAsync(x => x.Id == table.Id);

                if (existing == null) return 0;

                existing.FullName = table.FullName;
                existing.UserName = table.UserName;
                existing.Password = table.Password;
                existing.Email = table.Email;
                existing.Phone = table.Phone;

                existing.RecoveryCode = table.RecoveryCode;
                existing.RecoveryCodeExpiry = table.RecoveryCodeExpiry;
                existing.SecurityAnswer = table.SecurityAnswer;
                existing.SecurityQuestion = table.SecurityQuestion;

                await db.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.EditAsync");
                return 0;
            }
        }

        public Users Find(int Id)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Users.FirstOrDefault(x => x.Id == Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.Find");
                return null;
            }
        }

        public async Task<Users> FindAsync(int Id)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Users.FirstOrDefaultAsync(x => x.Id == Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.FindAsync");
                return null;
            }
        }

        public List<Users> GetAllData()
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Users.ToList();
                }
                else
                {
                    return new List<Users>();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.GetAllData");
                return new List<Users>();
            }
        }

        public async Task<List<Users>> GetAllDataAsync()
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Users.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.GetAllDataAsync");
            }

            return new List<Users>();

        }

        public List<Users> Search(string SearchItem)
        {
            try
            {
                if (db.Database.CanConnect())
                {
                    return db.Users.Where(x => x.Id.ToString() == SearchItem
                    || x.UserName.Contains(SearchItem)
                    || x.FullName.Contains(SearchItem)
                    || x.Email.Contains(SearchItem)
                    || x.Phone.Contains(SearchItem)
                    || x.AddedDate.Date.ToString().Contains(SearchItem)
                    )
                        .ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex )
            {
                Logger.Log(ex, "UsersEntity.Search");
                return null;
            }
        }

        public async Task<List<Users>> SearchAsync(string SearchItem)
        {
            try
            {
                if (await db.Database.CanConnectAsync())
                {
                    return await db.Users.Where(x => x.Id.ToString() == SearchItem
                    || x.UserName.Contains(SearchItem)
                    || x.FullName.Contains(SearchItem)
                    || x.Email.Contains(SearchItem)
                    || x.Phone.Contains(SearchItem)
                    || x.AddedDate.Date.ToString().Contains(SearchItem)
                    )
                        .ToListAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "UsersEntity.SearchAsync");
                return null;
            }
        }

        public async Task<Users> GetByUserNameAsync(string userName)
        {
            string normalized = userName.Trim().ToLower();
            return await db.Users
                .FirstOrDefaultAsync(x => x.UserName.ToLower().Trim() == normalized);
        }

        public async Task UpdateAsync(Users user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
        }
    }
}
