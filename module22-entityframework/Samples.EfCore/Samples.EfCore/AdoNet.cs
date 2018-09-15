using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Samples.EfCore
{
    [TestClass]
    public class AdoNet
    {
        [TestMethod]
        public void SimpleExample()
        {
            string connectionString = @"Data Source=.\sql2014;Initial Catalog=Samples_EfCore;Integrated Security=SSPI;MultipleActiveResultSets=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Students", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        Debug.WriteLine($"    {reader[0]}; {reader[1]}");
                    reader.Close();
                }
            }
            
        }
    }
}
