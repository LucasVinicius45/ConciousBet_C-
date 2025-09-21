using MySql.Data.MySqlClient;

namespace ConsciousbetApp.Utils
{
    public class Database
    {
        private static string connectionString = "server=localhost;database=aposta;user=root;password=Lucas414156?;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
