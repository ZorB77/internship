using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace AssignementTransaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting connection...");

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Company;"
        + "Integrated Security=true;");
            try
            {
                Console.WriteLine("Openning connection...");
                connection.Open();
                Console.WriteLine("Connection succesfull!");

                void makeTransaction(string id, string iban, SqlMoney amount)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("exec doTransaction @id_sender = " + id + ", @iban_reciver = " + iban + ", @amount = " + amount);

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString());

                            }
                        }
                    }
                }

                void ConsoleMenu()
                {
                    bool running = true;
                    while (running)
                    {
                        Console.WriteLine("Select an option:");
                        Console.WriteLine("1: Make a transaction");
                        Console.WriteLine("x: Exit");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                Console.WriteLine("Enter your id:");
                                string id = Console.ReadLine();
                                Console.WriteLine("Enter iban:");
                                string iban = Console.ReadLine();
                                Console.WriteLine("Enter amounty:");
                                SqlMoney amount = SqlMoney.Parse(Console.ReadLine());
                                makeTransaction(id, iban, amount);
                                break;
                            case "x":
                                running = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option, please try again.");
                                break;
                        }
                    }
                }

                ConsoleMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.Read();
        }
    }
}
