using CapaDatos.DB;
using CapaEntidades.PEU;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.PEU
{
    public class D_PEU_Listar
    {
        private SqlConnection cn;
        private Conexion MiConexi = new Conexion();
        private E_PEU_Persona persona = new E_PEU_Persona();
        SqlCommand cmd = new SqlCommand();

        public List<E_PEU_Persona> D_listEmpleados()
        {
            List<E_PEU_Persona> E_list = new List<E_PEU_Persona>();
            try
            {
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["desbaco"].ConnectionString);
                cmd = new SqlCommand("listame", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    E_PEU_Persona e_PEU_Persona = new E_PEU_Persona();
                    e_PEU_Persona.id = rdr["PersonaID"].ToString();
                    e_PEU_Persona.Nombre = rdr["LastName"].ToString();
                    E_list.Add(e_PEU_Persona);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Errror al iniciar el sistema " + e);
            }
            finally
            {
                cn.Close();
            }
            return E_list;
        }






    }

}
