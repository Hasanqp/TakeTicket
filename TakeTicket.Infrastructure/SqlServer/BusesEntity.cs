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
    public class BusesEntity : IDataHelper<Buses>, IBusRepository
    {
        // Variables
        private readonly DBContext _context;
        private Buses table;
        // Constructors
        public BusesEntity(DBContext context)
        {
            _context = context;
        }

        public int Add(Buses table)
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    _context.Buses.Add(table);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.Add");
                return 0;
            }
        }

        public async Task<int> AddAsync(Buses table)
        {
            try
            {
                if (await _context.Database.CanConnectAsync())
                {
                    await _context.Buses.AddAsync(table);
                    await _context.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.AddAsync");
                return 0;
            }
        }

        public int Delete(int Id)
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    table = Find(Id);
                    _context.Buses.Remove(table);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.Delete");
                return 0;
            }
        }

        public async Task<int> DeleteAsync(int Id)
        {
            try
            {
                if (await _context.Database.CanConnectAsync())
                {
                    table = await FindAsync(Id);
                    _context.Buses.Remove(table);
                    await _context.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.DeleteAsync");
                return 0;
            }
        }

        public int Edit(Buses table)
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    //context = new DBContext();
                    _context.Buses.Update(table);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.Edit");
                return 0;
            }
        }

        public async Task<int> EditAsync(Buses table)
        {
            try
            {
                if (!await _context.Database.CanConnectAsync())
                    return 0;

                var existingBus = await _context.Buses
                    .FirstOrDefaultAsync(x => x.Id == table.Id);

                if (existingBus == null)
                    return 0;

                existingBus.BusNumber = table.BusNumber;
                existingBus.BusDriver = table.BusDriver;
                existingBus.BusDriverAssistant = table.BusDriverAssistant;
                existingBus.PhoneNumber = table.PhoneNumber;
                existingBus.Address = table.Address;
                existingBus.Details = table.Details;
                existingBus.TripType = table.TripType;
                existingBus.StartDate = table.StartDate;
                existingBus.FinishDate = table.FinishDate;
                existingBus.BusNo = table.BusNo;
                existingBus.Capacity = table.Capacity;
                existingBus.ExtraCapacity = table.ExtraCapacity;
                existingBus.BusModel = table.BusModel;

                await _context.SaveChangesAsync();
                    return 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.EditAsync");
                return 0;
            }
        }

        public Buses Find(int Id)
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    return _context.Buses.FirstOrDefault(x => x.Id == Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.Find");
                return null;
            }
        }

        public async Task<Buses> FindAsync(int Id)
        {
            try
            {
                if (await _context.Database.CanConnectAsync())
                {
                    return await _context.Buses.FirstOrDefaultAsync(x => x.Id == Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.FindAsync");
                return null;
            }
        }

        public List<Buses> GetAllData()
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    return _context.Buses.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.GetAllData");
                return null;
            }
        }

        public async Task<List<Buses>> GetAllDataAsync()
        {
            try
            {
                if (await _context.Database.CanConnectAsync())
                {
                    return await _context.Buses.ToListAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.GetAllDataAsync");
                return null;
            }
        }

        public List<Buses> Search(string SearchItem)
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    return _context.Buses.Where(x => x.Id.ToString() == SearchItem
                    || x.BusDriver.Contains(SearchItem)
                    || x.BusDriverAssistant.Contains(SearchItem)
                    || x.BusNumber.Contains(SearchItem)
                    || x.BusNo.ToString().Contains(SearchItem)
                    || x.Address.Contains(SearchItem)
                    || x.PhoneNumber.Contains(SearchItem)
                    || x.Details.Contains(SearchItem)
                    || x.AddedDate.Date.ToString().Contains(SearchItem)
                    || x.TripType.Contains(SearchItem)
                    || x.StartDate.ToString().Contains(SearchItem)
                    || x.FinishDate.ToString().Contains(SearchItem)
                    ).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "BusesEntity.Search");
                return null;
            }
        }

        public async Task<List<Buses>> SearchAsync(string SearchItem)
        {
            try
            {
                if (await _context.Database.CanConnectAsync())
                {
                    return await _context.Buses.Where(x => x.Id.ToString() == SearchItem
                    || x.BusDriver.Contains(SearchItem)
                    || x.BusDriverAssistant.Contains(SearchItem)
                    || x.BusNumber.Contains(SearchItem)
                    || x.BusNo.ToString().Contains(SearchItem)
                    || x.Address.Contains(SearchItem)
                    || x.PhoneNumber.Contains(SearchItem)
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
                Logger.Log(ex, "BusesEntity.SearchAsync");
                return null;
            }
        }

        public async Task<bool> IsBusNumberExists(string busNumber, int? excludeId = null)
        {
            return await _context.Buses
                .AnyAsync(x => x.BusNumber == busNumber && x.Id != excludeId);
        }

        public async Task<bool> IsBusNoExists(int busNo, int? excludeId = null)
        {
            return await _context.Buses
                .AnyAsync(x => x.BusNo == busNo && x.Id != (excludeId ?? 0));
        }
    }
}
