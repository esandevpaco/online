using CapaDatos.DB;
using CapaEntidades.PEU;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos.PEU
{
    public class D_PEU_Persons
    {
        private List<E_PEU_Persons> E_list = new List<E_PEU_Persons>();
        private readonly Conexion con = new Conexion();
       


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
                                        e_PEU_Persons.Nombre = reader["LastName"].ToString();
                                        e_PEU_Persons.id = reader["PersonID"].ToString();
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



        public  async Task<bool> D_InsertarEmpleados(string value1)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["desbaco"].ConnectionString;
            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string insertQuery = "INSERT INTO Persons (LastName) VALUES (@Value1)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Set parameter values
                        insertCommand.Parameters.AddWithValue("@Value1", value1);
       

                        // Execute the insert command asynchronously
                        int rowsAffected = await insertCommand.ExecuteNonQueryAsync();

                        // Check if any rows were affected
                        isSuccess = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inserting data:" + ex.Message);
           
                }
            }

            return isSuccess;
        }





    }

    //CREATE PROCEDURE SP_APP_TESTEO_DETALLE
    //    AS
    //    BEGIN
    //    SELECT*, des_ape_pat FROM[dbo].[crm_contacto]
    //        END

}
