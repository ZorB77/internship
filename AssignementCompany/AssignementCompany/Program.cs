using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace AssignementCompany
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

                void addEmplyee(string firstname, string lastname, SqlMoney salary)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into Employee (firstName, lastName, salary) values (@firstName, @lastName, @salary)");

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstname);
                        command.Parameters.AddWithValue("@lastName", lastname);
                        command.Parameters.AddWithValue("@salary", salary);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Employee inserted succesfully!!");
                    }
                }

                void updateSalary(int id, SqlMoney newSalary)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("exec updateSalary @id = "+ id +", @salary = " + newSalary);

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Salary updated succesfully!");
                    }
                }

                void deleteEmployee(int id)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from Employee where id = "+id);

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Employee deleted succesfully!");
                    }
                }

                void getEmplyeeSalarybyId(int id)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("exec getEmployeeSalaryById @id = " + id);

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if(reader[0].ToString() == "-1")
                                {
                                    Console.WriteLine("Invalid employee id");
                                }
                                else
                                {
                                    Console.WriteLine("Employee's salary:" + reader[0].ToString());
                                }
                            }
                        }
                    }
                }

                void seeSalaryHistory(int id)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("exec getEmployeeHistorySalary @id = " + id);

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Employee's old salary:" + reader[0].ToString() + ", new salary:" + reader[1].ToString() + ", date modified:" + reader[2].ToString());
                            }
                        }
                    }
                }

                void seeAllEmployees()
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from Employee");

                    string sqlQuery = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Employee's id:" + reader[0].ToString() + ", first name:" + reader[1].ToString() + ", last name:" + reader[2].ToString() + ", salary:" + reader[3
                                    ].ToString());
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
                        Console.WriteLine("1: Add employee");
                        Console.WriteLine("2: Update the salary of an employee");
                        Console.WriteLine("3: Delete employee");
                        Console.WriteLine("4: Get employee's salary by id of an employee");
                        Console.WriteLine("5: See the salary history of an employee");
                        Console.WriteLine("6: See all employees");
                        Console.WriteLine("7: Exit");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                               
                                Console.WriteLine("Enter employee first name:");
                                string firstname = Console.ReadLine();
                                Console.WriteLine("Enter employee last name:");
                                string lastname = Console.ReadLine();
                                Console.WriteLine("Enter employee salary:");
                                SqlMoney salary = SqlMoney.Parse(Console.ReadLine());
                                addEmplyee(firstname, lastname, salary);
                                break;
                            case "2":
                                Console.WriteLine("Enter the id of the employee:");
                                int id_employee = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enterthe new salary:");
                                SqlMoney new_Salary = SqlMoney.Parse(Console.ReadLine());
                                updateSalary(id_employee, new_Salary);
                                break;
                            case "3":
                                Console.WriteLine("Enter the id of the employee you want to delete:");
                                int id = int.Parse(Console.ReadLine());
                                deleteEmployee(id);
                                break;
                            case "4":
                                Console.WriteLine("Enter the id of the employee you want to get the salary:");
                                id = int.Parse(Console.ReadLine());
                                getEmplyeeSalarybyId(id);
                                break;
                            case "5":
                                Console.WriteLine("Enter the id of the employee you want to see the salary history:");
                                id = int.Parse(Console.ReadLine());
                                seeSalaryHistory(id);
                                break;
                            case "6":
                                seeAllEmployees();
                                break;
                            case "7":
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
                Console.WriteLine("Error: "+e.Message);
            }
            Console.Read();
        }
    }
}
