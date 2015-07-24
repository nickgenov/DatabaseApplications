using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace Transaction_Scope_Redo
{
    class TransactionScopeRedo
    {
        private const string CONNECTION_STRING = @"Server=.\SQL2014; " +
        "Database=SoftUni; Integrated Security=true";

        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(CONNECTION_STRING);

            using (dbCon)
            {
                using (var transaction = new TransactionScope())
                {
                    dbCon.Open();

                    try
                    {
                        Console.WriteLine("Transaction started.");

                        SqlCommand cmd = dbCon.CreateCommand();
                        cmd.CommandText = "INSERT INTO Towns(Name) VALUES ('Transaction scope town')";
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted a new record.");

                        cmd.CommandText = "INSERT INTO Towns(Name) VALUES (NULL)";
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted a new record.");

                        transaction.Complete();
                        Console.WriteLine("Transaction completed.");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("An exception has occurred: {0}", e.Message);
                        Console.WriteLine("Transaction cancelled.");
                    }
                }
            }
        }
    }
}