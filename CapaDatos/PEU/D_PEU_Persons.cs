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
    public class D_PEU_Persons
    {
       
     public List<E_PEU_Persons> D_ListPerson()
        {
            List<E_PEU_Persons> E_list = new List<E_PEU_Persons>();
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["desbaco"].ConnectionString);
                SqlCommand cmd = new SqlCommand("listame", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    E_PEU_Persons e_PEU_Persons = new E_PEU_Persons();
                    e_PEU_Persons.Nombre = rdr["LastName"].ToString();
                    e_PEU_Persons.Apellido = rdr["FirstName"].ToString();
                    E_list.Add(e_PEU_Persons);

                }
            }
            catch (Exception e)
            {
                throw new Exception("Errror al iniciar el sistema " + e);
            }

            return E_list;
        }






    }

}
