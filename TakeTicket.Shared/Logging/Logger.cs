using TakeTicket.Shared.Paths;

namespace TakeTicket.Shared.Common.Logging
{
    public static class Logger
    {
        private static readonly string logFolder = AppPaths.LogsFolder;

        private static readonly object _lock = new object();

        private static void EnsureLogFolder()
        {
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);
        }

        private static void Write(string fileName, string content)
        {
            try
            {
                EnsureLogFolder();

                string filePath = Path.Combine(
                    logFolder,
                    $"{fileName}-{DateTime.Now:yyyy-MM-dd}.txt");

                lock (_lock) // مهم جدًا
                {
                    File.AppendAllText(filePath, content);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        public static void Log(Exception ex, string source = "")
        {
            string message =
$@"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 
Source: {source}
Message: {ex.Message}
Inner: {ex.InnerException?.Message}
StackTrace:
{ex.StackTrace}
------------------------------------------------
";

            Write("log", message);
        }

        public static void Log(string message)
        {
            Write("log",
                
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
        }

        public static void Audit(string message, string user = "")
        {
            Write("audit",
                $"[{DateTime.Now:HH:mm:ss}] User={user} {message}{Environment.NewLine}");
        }
    }
}
