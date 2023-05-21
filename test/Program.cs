using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Odbc;
namespace test
{
    public class Program
    {
  
        static void Main(string[] args)
        {
            string DB = "empresa";
            string Servidor = "DESKTOP-NFF8OB1\\SQLEXPRESS";
            string Usuario = "";
            string Clave = "";

            try
            {
                string connectionString = $"Data Source={Servidor};Initial Catalog={DB}; Integrated Security = true;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                Console.WriteLine("Exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }

            Console.ReadKey();

        }
    }
}
