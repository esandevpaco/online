using CapaDatos.DB;
using CapaEntidades.PEU;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos.PEU
{
    public class D_PEU_Persons
    {
        private List<E_PEU_Persons> E_list = new List<E_PEU_Persons>();
        private SqlConnection cn;
        public async  Task <List<E_PEU_Persons>> D_ListPerson()
        {
            return await Task.Run(() => {
            try
            {
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["desbaco"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SP_APP_TESTEO_DETALLE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    E_PEU_Persons e_PEU_Persons = new E_PEU_Persons();
                    e_PEU_Persons.Nombre = rdr["des_nombre"].ToString();
                    e_PEU_Persons.Apellido = rdr["des_ape_pat"].ToString();
                    E_list.Add(e_PEU_Persons);

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

            });
        }

    }

    //CREATE PROCEDURE SP_APP_TESTEO_DETALLE
    //    AS
    //    BEGIN
    //    SELECT*, des_ape_pat FROM[dbo].[crm_contacto]
    //        END

}
