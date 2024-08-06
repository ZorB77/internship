using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace SalariatiDB
{
    static class OperatiiSalariale
    {
        static string connString = @"Data Source=localhost;Initial Catalog=SalariatiPB1;Integrated Security=True;TrustServerCertificate=True";

        public static void AfisareSalariu(int id)
        {

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    SqlCommand procedure = new SqlCommand("dbo.angAfisareSalariu", conn);
                    procedure.CommandType = System.Data.CommandType.StoredProcedure;
                    procedure.Parameters.Add("@AngajatID", System.Data.SqlDbType.Int).Value = id;
                    procedure.Parameters.Add("@Salariu", System.Data.SqlDbType.Money).Direction = System.Data.ParameterDirection.Output;
                    conn.Open();
                    procedure.ExecuteNonQuery();
                    var salariu = Convert.ToDecimal(procedure.Parameters["@Salariu"].Value);
                    conn.Close();
                    Console.WriteLine($"Salariul pentru id {id} este {salariu}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public static void ActualizareSalariu(int id, decimal salariuNou)
        {

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    SqlCommand procedure = new SqlCommand("dbo.angActualizareSalariu", conn);
                    procedure.CommandType = System.Data.CommandType.StoredProcedure;
                    procedure.Parameters.Add("@AngajatID", System.Data.SqlDbType.Int).Value = id;
                    procedure.Parameters.Add("@Salariu", System.Data.SqlDbType.Money).Value = salariuNou;
                    conn.Open();
                    procedure.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine($"Salariul pentru angajatul cu {id} s-a actualizat cu succes.");
                    AfisareSalariu(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

        }
    }
}
