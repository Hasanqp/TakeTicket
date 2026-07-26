namespace TakeTicket.Shared.Paths
{
    public static class AppPaths
    {
        public static string AppDataFolder =>
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "TakeTicket");

        public static string LogsFolder =>
            Path.Combine(AppDataFolder, "Logs");

        public static string TicketsFolder =>
            Path.Combine(AppDataFolder, "Tickets");

        public static string DatabaseFolder =>
            Path.Combine(AppDataFolder, "Database");
    }
}
