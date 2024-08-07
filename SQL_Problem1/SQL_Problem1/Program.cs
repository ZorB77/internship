using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;

class Program 
{
    static void Main()
    {
        Console.WriteLine("Salary Update");
        Console.WriteLine("Enter Employee ID: ");
        int employeeID = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter new salary: ");
        float salary = float.Parse(Console.ReadLine());
        // Initiere conexiune SQL
        using (SqlConnection connection = new SqlConnection("Data Source=RTB42;Initial Catalog=prob;Integrated Security=True;Trust Server Certificate=True"))
        {
            // Procedura UpdateEmployeeSalary
            SqlCommand command = new SqlCommand("UpdateEmployeeSalary", connection);
            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
            command.Parameters.Add(new SqlParameter("@NewSalary", salary));

            command.ExecuteNonQuery();
            // Procedura GetEmployeeSalary
            command = new SqlCommand("GetEmployeeSalary", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("Updated salary: " + reader.GetDouble(0));
                }

            }

            command = new SqlCommand("SELECT TOP 1 * FROM SalaryHistory ORDER BY SalaryID DESC", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("EmployeeID: " + reader.GetInt32(1));
                    Console.WriteLine("Old Salary: " + reader.GetDouble(2));
                    Console.WriteLine("New Salary: " + reader.GetDouble(3));
                    Console.WriteLine("Date when the salary changed: " + reader.GetDateTime(4));
                }

            }

        }
    }
}