using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Update salary");
                Console.WriteLine("2 - Salary history");

                Console.WriteLine("Select option:");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        UpdateSalary();
                        break;
                    case "2":
                        SalaryHistory();
                        break;
                    default:
                        break;
                }
            }
        }

        static void UpdateSalary()
        {
            Console.WriteLine("Enter the employee id: ");
            var employeeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new salary: ");
            int salary = int.Parse(Console.ReadLine());


            using (SqlConnection sqlConnection = new SqlConnection(@"server=DESKTOP-MR90OCN;database=Test;Integrated Security=True"))
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.updateEmployeeSalary", sqlConnection);
                Console.Write("Connecting to the server...\n");

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Salary", salary);
                sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                var result = Convert.ToBoolean(sqlCommand.Parameters["@Salary"].Value);
            }

            Console.WriteLine("The salary for employee {0} is {1}", employeeId, salary);
        }

        static void SalaryHistory()
        {
            Console.WriteLine("Enter the employee id:");
            var employeeId = int.Parse(Console.ReadLine());

            using (SqlConnection sqlConnection = new SqlConnection(@"server=DESKTOP-MR90OCN;database=Test;Integrated Security=True"))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Salaries WHERE EmployeeID = @EmployeeID", sqlConnection);
                Console.Write("Connecting to the server...\n");

                sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine("The salary history for employee {0}: ", employeeId);
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Salary"].ToString());
                    }
                }
            }


        }
    }
}