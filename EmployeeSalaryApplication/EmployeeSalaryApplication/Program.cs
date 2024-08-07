using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeSalaryApplication
{
    class Program
    {

        static void printMenu()
        {
            Console.WriteLine("1. See all employees.");
            Console.WriteLine("2. Update the salary of an employee.");
            Console.WriteLine("3. See salary modifications.");
            Console.WriteLine("4. Print the salary of a given employee.");
            Console.WriteLine("0. Exit application.");
        }

        static void Main()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=EmployeeSalary;Integrated Security=True");
            Console.Write("Connecting to SQL Server... \n");
            using (connection)
            {
                connection.Open();
                Console.Write("Successfully connected to the database.\n");

                while (true)
                {
                    printMenu();
                    Console.Write("Option:");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 0)
                    {
                        break;
                    }
                    else if (option == 1)
                    {
                        SqlCommand command = new SqlCommand("select * from Employee", connection);
                        using (command)
                        {
                            try
                            {
                                SqlDataReader reader = command.ExecuteReader();
                                using (reader)
                                {
                                    Console.WriteLine("EmployeeID\tFirstName\tLastName\tSalary\tAddress\t\tBirthDate");
                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"{reader["employeeID"]}         \t{reader["firstName"]}        \t{reader["lastName"]}        \t{reader["salary"]}\t{reader["address"]}\t    {reader["birthDate"]}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                    }
                    else if (option == 2)
                    {


                        Console.Write("Enter employee ID: ");
                        int employeeID = int.Parse(Console.ReadLine());

                        Console.Write("Enter new salary: ");
                        float newSalary = float.Parse(Console.ReadLine());

                        SqlCommand command = new SqlCommand("UpdateEmployeeSalary", connection);

                        using (command)
                        {
                            try
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@employeeID", employeeID);
                                command.Parameters.AddWithValue("@newSalary", newSalary);

                                command.ExecuteNonQuery();
                                Console.WriteLine("Salary updated successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }

                        SqlCommand command2 = new SqlCommand("GetEmployeeSalary", connection);

                        using (command2)
                        {
                            try
                            {
                                command2.CommandType = CommandType.StoredProcedure;
                                command2.Parameters.AddWithValue("@employeeID", employeeID);

                                SqlDataReader reader = command2.ExecuteReader();

                                    if (reader.Read())
                                    {
                                        Console.WriteLine(reader["Result"].ToString());
                                    }
                                    reader.Close();
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                    }
                    else if (option == 3)
                    {
                        SqlCommand command = new SqlCommand("select * from EmployeeSalaryHistory", connection);
                        using (command)
                        {
                            try
                            {
                                SqlDataReader reader = command.ExecuteReader();
                                using (reader)
                                {
                                    Console.WriteLine("EmployeeSalaryID\tEmployeeID\toldSalary\tnewSalary\tdateOfChange");
                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"{reader["employeeSalaryID"]}\t                 {reader["employeeID"]}\t         {reader["oldSalary"]}\t         {reader["newSalary"]}\t            {reader["dateOfChange"]}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                    }
                    else if (option == 4)
                    {
                        Console.Write("Enter employee ID: ");
                        int employeeID = int.Parse(Console.ReadLine());
                        SqlCommand command = new SqlCommand("select salary as Result from Employee where employeeID = " + employeeID.ToString(), connection);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            Console.WriteLine("The salary is " + reader["Result"].ToString() + ".");
                        }
                        reader.Close();
                    }
                }
            }
        }
    }
}