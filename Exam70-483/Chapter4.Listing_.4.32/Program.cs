using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToDatabase().Wait();

            Console.ReadLine();
        }

        private static async Task ConnectToDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Testdatabase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM People", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    string formatStringWithMiddleName = "Person ({0}) is named {1} {2} {3}";
                    string formatStringWitoutMiddleName = "Person ({0}) is named {1} {2}";

                    if (dataReader["middlename"] == null)
                    {
                        Console.WriteLine(formatStringWitoutMiddleName,
                            dataReader["Id"],
                            dataReader["firstname"],
                            dataReader["lastname"]);
                    }
                    else
                    {
                        Console.WriteLine(formatStringWithMiddleName,
                           dataReader["Id"],
                           dataReader["firstname"],
                           dataReader["middlename"],
                           dataReader["lastname"]);
                    }
                }

                dataReader.Close();
            }
        }
    }
}
