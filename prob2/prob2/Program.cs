using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.WriteLine("Transfer Funds");
        Console.WriteLine("Enter your ID: ");
        int senderID = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter receiver ID: ");
        int receiverID = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the amount: ");
        float amount = float.Parse(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection("Data Source=RTB42;Initial Catalog=prob2;Integrated Security=True;Trust Server Certificate=True"))
        {
            SqlCommand command = new SqlCommand("TransferFunds", connection);
            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@FromAccountID", senderID));
            command.Parameters.Add(new SqlParameter("@ReceiverAccountID", receiverID));
            command.Parameters.Add(new SqlParameter("@Amount", amount));

            command.ExecuteNonQuery();

            command = new SqlCommand("Select * from BankAccounts", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) {
                    Console.WriteLine("First Name: " + reader.GetString(1));
                    Console.WriteLine("Last Name: " + reader.GetString(2));
                    Console.WriteLine("Balance: " + reader.GetDouble(3));
                
                }
            
            
            }

        }
    
    }


}
