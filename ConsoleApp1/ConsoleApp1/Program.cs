using System;
using System.Data;
using Microsoft.Data.SqlClient;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("getting connection");

        string connectionString = "Server=DESKTOP-U8NIF1Q;Database=Exercise1;Trusted_Connection=True;TrustServerCertificate=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("The connection was successful!");
            Console.WriteLine("1.Update Salary");
            Console.WriteLine("2.Display the salary");
            Console.WriteLine("3.Display the Old Salaries");
            Console.WriteLine("Choose one option:");
            

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("First name of the employee:");
            string Firstname = Console.ReadLine();
            Console.WriteLine("Last name of the employee: ");
            string LastName = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("the new salary: ");
                    decimal NewSalary = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Write the reason to change the salary:");
                    string ChangeReason = Console.ReadLine();
                    UpdateTheSalary(connection, Firstname,LastName,NewSalary,ChangeReason);
                    break;
                case 2:
                    DisplaySalary(connection, Firstname, LastName);
                    break;
                case 3:
                    DisplayOldSalary(connection, Firstname, LastName);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                        break;
            }
        }
    }
        static void UpdateTheSalary(SqlConnection connection,string FirstName, string LastName,decimal NewSalary,string ChangeReason)
        {
        using (SqlCommand cmd = new SqlCommand("updtdemployee", connection))
        {
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@NewSalary", NewSalary);
            cmd.Parameters.AddWithValue("@ChangeReason", ChangeReason);

            int rowsChanged = cmd.ExecuteNonQuery();
        }
        }

    static void DisplaySalary(SqlConnection connection,string FirstName, string LastName)
        {
            using (SqlCommand cmd = new SqlCommand("GetSalary", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var salary = reader["Salary"];
                    Console.WriteLine(salary);
                }
                reader.Close();

            }
        
    }

    static void DisplayOldSalary(SqlConnection connection, string FirstName,string LastName)
    {
        using (SqlCommand cmd = new SqlCommand("GetOldSalaries", connection))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var OldSalary = reader["OldSalaries"];
                var newSalary = reader["NewSalary"];
                var changeDate = reader["ChangedDate"];
                var changedReason = reader["ChangeReason"];
                Console.WriteLine("The old salary: {0}, The new salary: {1}, changedDate: {2}, changesReason: {3}", OldSalary, newSalary, changeDate, changedReason);

            }
        }
    }


    

    
}
