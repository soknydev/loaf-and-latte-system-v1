using Npgsql;

namespace bakery_management_system.Utils
{
    public static class DatabaseHelper
    {
        private static string server = "dpg-d05n6q3uibrs73fsa2pg-a.oregon-postgres.render.com";
        private static string database = "bakery_seyha";
        private static string userId = "bakery_seyha_user";
        private static string password = "AqvPjXANFVFIQwBSpANSTvbXJLDRKIux";  // replace with your actual password
        private static int port = 5432;

        // Construct the PostgreSQL connection string
        private static readonly string connectionString =
            $"Host={server};Port={port};Database={database};Username={userId};Password={password};";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
