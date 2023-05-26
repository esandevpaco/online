using System.Configuration;
using System.Data.SqlClient;

namespace CapaDatos.DB
{
    public class Conexion
    {

        public string connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["desbaco"].ConnectionString;
            return connectionString;
        }

    }
}
