using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Exercise2
    {

        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-U8NIF1Q;Database=Exercise1;Trusted_Connection=True;TrustServerCertificate=True;";


            Console.WriteLine("The connection was successful!");
            Console.WriteLine("First name of the sender:");
            string FirstNameFrom = Console.ReadLine();
            Console.WriteLine("Last name of the sender:");
            string LastNameFrom = Console.ReadLine();

            Console.WriteLine("First Name of the receiver");
            string FirstNameTo = Console.ReadLine();
            Console.WriteLine("Last Name of the receiver:");
            string LastNameTo = Console.ReadLine();

            Console.WriteLine("Enter the amount of money:");
            decimal amount = decimal.Parse(Console.ReadLine());


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("The connection was successful!");

                    using (SqlCommand cmd = new SqlCommand("Transfers", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstNameFrom", FirstNameFrom);
                        cmd.Parameters.AddWithValue("@LastNameFrom", LastNameFrom);
                        cmd.Parameters.AddWithValue("@FirstNameTo", FirstNameTo);
                        cmd.Parameters.AddWithValue("@LastNameTo", LastNameTo);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("The transfer was successful!");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
