using Npgsql;

namespace bakery_management_system.Utils
{
    public static class DatabaseHelper
    {
        private static string server = "localhost";
        private static string database = "postgres";
        private static string userId = "postgres";
        private static string password = "1234dev";  // replace with your actual password
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
