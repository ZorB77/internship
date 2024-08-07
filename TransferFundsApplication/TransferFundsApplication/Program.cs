
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7M2ITU5;Initial Catalog=BankTransactions;Integrated Security=True");
        Console.Write("Connecting to SQL Server... \n");
        using (connection)
        {
            connection.Open();
            Console.WriteLine("Successfully connected to the database.\n");

            Console.Write("Enter sender ID: ");
            int senderID = int.Parse(Console.ReadLine());

            Console.Write("Enter receiver ID: ");
            int receiverID = int.Parse(Console.ReadLine());

            Console.Write("Enter amount: ");
            float amount = float.Parse(Console.ReadLine());

            using (SqlCommand command = new SqlCommand("TransferFunds", connection))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@senderAccount", senderID);
                    command.Parameters.AddWithValue("@receiverAccount", receiverID);
                    command.Parameters.AddWithValue("@amount", amount);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Amount transfered successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
