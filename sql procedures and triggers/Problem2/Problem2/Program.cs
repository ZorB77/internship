using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MoneyTransfer();
        }

        static void MoneyTransfer()
        {
            Console.WriteLine("From account id: ");
            var fromAccountID = int.Parse(Console.ReadLine());

            Console.WriteLine("To account id: ");
            var toAccountID = int.Parse(Console.ReadLine());

            Console.WriteLine("The amount you want to transfere: ");
            var amount = decimal.Parse(Console.ReadLine());


            using (SqlConnection sqlConnection = new SqlConnection(@"server=DESKTOP-MR90OCN;database=Test;Integrated Security=True"))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.moneyTransfere", sqlConnection);
                    Console.Write("Connecting to the server...\n");

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FromAccountID", fromAccountID);
                    sqlCommand.Parameters.AddWithValue("@ToAccountID", toAccountID);
                    sqlCommand.Parameters.AddWithValue("@Amount", amount);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Transaction succesfully!");
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
             
            }
        }
    }
}