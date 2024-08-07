// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
string connString = @"Data Source=localhost;Initial Catalog=BineriBank;Integrated Security=True;TrustServerCertificate=True";

string expeditorIBAN = "RO11BBRADU";
string destinatarIBAN = "RO11BBDAVID";
decimal suma = 2.5m;

try
{
    using (var conn = new SqlConnection(connString))
    {
        SqlCommand procedure = new SqlCommand("dbo.bbTransferBancar", conn);
        procedure.CommandType = System.Data.CommandType.StoredProcedure;
        procedure.Parameters.Add("@ExpeditorIBAN", System.Data.SqlDbType.VarChar).Value = expeditorIBAN;
        procedure.Parameters.Add("@DestinatarIBAN", System.Data.SqlDbType.VarChar).Value = destinatarIBAN;
        procedure.Parameters.Add("@Suma", System.Data.SqlDbType.Money).Value = suma;
        procedure.Parameters.Add("@Mesaj", System.Data.SqlDbType.VarChar, 50).Direction = System.Data.ParameterDirection.Output;
        conn.Open();
        procedure.ExecuteNonQuery();
        var mesaj= Convert.ToString(procedure.Parameters["@Mesaj"].Value);
        conn.Close();
        Console.WriteLine($"{mesaj}");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}

// it would be nice to have menu or to input the IBANs or the amount, besides that, it looks ok
