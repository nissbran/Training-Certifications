using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertRowWithTransaction();

            Console.ReadLine();
        }

        private static void InsertRowWithTransaction()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Testdatabase"].ConnectionString;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1 = new SqlCommand("INSERT INTO People([FirstName],[LastName],[MiddleName]) VALUES('John', 'Doe', null)",
                        connection);
                    SqlCommand command2 = new SqlCommand("INSERT INTO People([FirstName],[LastName],[MiddleName]) VALUES('John', 'Doe', null)",
                       connection);

                    var numberOfInsertedRows = command1.ExecuteNonQuery();
                    numberOfInsertedRows += command2.ExecuteNonQuery();

                    Console.WriteLine("Inserted {0} rows", numberOfInsertedRows);
                }
                transactionScope.Complete();
            }
           
        }
    }
}
