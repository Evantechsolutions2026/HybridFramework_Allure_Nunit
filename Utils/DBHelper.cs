using Framework.Utils;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework
{
    public class DBHelper
    {
       // Get Connection 
        public static SqlConnection GetConnection(string userType)
        {
            var user = ConfigReader.GetDbUser(userType);

            string server = ConfigReader.GetNested("database", "server");
            string dbName = ConfigReader.GetNested("database", "dbName");

            string connectionString =
                $"Server={server};Database={dbName};User Id={user.Username};Password={user.Password};TrustServerCertificate=True;";

            return new SqlConnection(connectionString);
        }
        // Async to read and store Data
        public static async Task<List<Dictionary<string, string>>> GetDBDataAsync(
            string query,
            string userType )
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            using (SqlConnection conn = GetConnection(userType))
            {
                await conn.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Dictionary<string, string> row = new Dictionary<string, string>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                string value;

                                if (reader[i] != null)
                                {
                                    value = reader[i].ToString();
                                }
                                else
                                {
                                    value = null;
                                }

                                row[columnName] = value;
                            }

                            result.Add(row);
                        }
                    }
                }
            }

            return result;
        }
        //var data = await DBHelper.GetDBDataAsync("SELECT * FROM Users");
        //string name = data[0]["Name"];

        // Getting First Row 
        public static async Task<Dictionary<string, string>> GetFirstRowAsync(
            string query,
            string userType)
        {
            var data = await GetDBDataAsync(query, userType);
            return data.Count > 0 ? data[0] : null;
        }
    }
}