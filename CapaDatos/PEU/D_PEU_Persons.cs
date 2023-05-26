using CapaDatos.DB;
using CapaEntidades.PEU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos.PEU
{
    public class D_PEU_Persons
    {
        private List<E_PEU_Persons> E_list = new List<E_PEU_Persons>();
        private readonly Conexion con = new Conexion();
        public async  Task <List<E_PEU_Persons>> D_ListPerson4()
        {       
            try
            {
                 return await Task.Run(() => {

                     using (SqlConnection connection = new SqlConnection(con.connection()))
                     {
                         SqlCommand cmd = new SqlCommand("SP_APP_TESTEO_DETALLE", connection);
                         cmd.CommandType = CommandType.StoredProcedure;
                         connection.Open();
                         SqlDataReader  reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             E_PEU_Persons e_PEU_Persons = new E_PEU_Persons();
                             e_PEU_Persons.Nombre = reader["des_nombre"].ToString();
                             e_PEU_Persons.Apellido = reader["des_ape_pat"].ToString();
                             E_list.Add(e_PEU_Persons);
                         }
                         return E_list;
                     }

                 });
            }
            catch (Exception e)
            {
                throw new Exception("Errror al iniciar el sistema " + e);
            }
          
        }


        public async Task<List<E_PEU_Persons>> D_ListPerson()
        {

            using (SqlConnection connection = new SqlConnection(con.connection()))
            {
                try
                {

                    connection.Open();
                  
                    using (SqlCommand command = new SqlCommand("SP_APP_TESTEO_DETALLE", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            return await Task.Run(() => {
                                    while (reader.Read())
                                    {
                                        E_PEU_Persons e_PEU_Persons = new E_PEU_Persons();
                                        e_PEU_Persons.Nombre = reader["des_nombre"].ToString();
                                        e_PEU_Persons.Apellido = reader["des_ape_pat"].ToString();
                                        E_list.Add(e_PEU_Persons);
                                    }
                                return E_list;
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Errror al iniciar el sistema " + ex);
                }
            }


        }


        }

    //CREATE PROCEDURE SP_APP_TESTEO_DETALLE
    //    AS
    //    BEGIN
    //    SELECT*, des_ape_pat FROM[dbo].[crm_contacto]
    //        END

}
