
using MySql.Data.MySqlClient;

namespace CafePOSSystem
{
    public static class Database
    {
        private static readonly string connectionString =
            "Server=localhost;Port=3306;Database=CafePOSDB;Uid=root;Pwd=123456;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
