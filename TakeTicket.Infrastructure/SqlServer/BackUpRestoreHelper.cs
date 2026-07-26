using Microsoft.EntityFrameworkCore;
using System;

namespace TakeTicket.Data.SqlServer
{
    public class BackUpRestoreHelper
    {
        private readonly DBContext _context;
        public BackUpRestoreHelper(DBContext context)
        {
            _context = context;
        }
        #region Methods
        public string BackUp(string Path)
        {
            try
            {
                _context.Database.SetCommandTimeout(0);
                string dbName = _context.Database.GetDbConnection().Database;
                string FileName = Path + dbName + DateTime.Now.ToString("yyyyMMddHHmm") + ".bak";
                string sqlquery = "BACKUP DATABASE [" + dbName + "] TO  DISK = N'" + FileName + "' WITH NOFORMAT, NOINIT,  NAME = N'" + dbName + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                _context.Database.ExecuteSqlRaw(sqlquery);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Restore(string FileName)
        {
            try
            {
                _context.Database.SetCommandTimeout(0);
                string dbName = _context.Database.GetDbConnection().Database;

                string AlterDbSetSingle = "ALTER DATABASE [" + dbName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                string AlterDbSetDouble = ";ALTER DATABASE [" + dbName + "] SET MULTI_USER";

                string sqlquery = AlterDbSetSingle + "USE [master];RESTORE DATABASE [" + dbName + "] FROM  DISK = N'" + FileName + "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 5" + AlterDbSetDouble;

                _context.Database.ExecuteSqlRaw(sqlquery);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }

}
