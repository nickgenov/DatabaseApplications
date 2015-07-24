using System;
using System.Transactions;
using System.Data.SqlClient;


namespace Transaction_Scope
{
    class TransactionScopeExample
    {
        private const string CONNECTION_STRING = @"Server=.\SQL2014; " +
        "Database=SoftUni; Integrated Security=true";
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(CONNECTION_STRING);

            using (dbCon)
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    dbCon.Open();

                    try
                    {
                        Console.WriteLine("Transaction started.");

                        SqlCommand cmd = dbCon.CreateCommand();
                        cmd.CommandText = "INSERT INTO Towns (Name) VALUES ('SOME RANDOM TOWN')";
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Inserted a new record.");

                        cmd.CommandText = "INSERT INTO Towns (Name) VALUES (NULL)";
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Inseted a new record");

                        transaction.Complete();
                        Console.WriteLine("Transaction completed.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Exception occurred: {0}", ex.Message);
                        Console.WriteLine("Transaction cancelled.");
                    }
                }
            }
        }
    }
}