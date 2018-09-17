using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System.Diagnostics;

namespace Samples.EfCore
{
    [TestClass]
    public class AdoNet
    {
        [TestMethod]
        public void SimpleExample()
        {
            string connectionString = @"UserID=postgres;Password=debug;Host=localhost;Port=5432;Database=sample";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM \"Students\"", connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        Debug.WriteLine($"    {reader[0]}; {reader[1]}");
                    reader.Close();
                }
            }
            
        }
    }
}
