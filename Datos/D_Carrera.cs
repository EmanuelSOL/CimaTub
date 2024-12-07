using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Datos
{

    
    public class D_Carrera : Conexion
    {
        public List<E_Carrera> ListarCarreras()
        {
            List<E_Carrera> carreras = new List<E_Carrera>();
            SqlCommand cmd = new SqlCommand("Listar_carrera", connection);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Carrera carrera = new E_Carrera()
                    {
                        IdCarrera = (int)reader["IdCarrera"],
                        Nombre = (string)reader["Nombre"]
                    };
                    carreras.Add(carrera);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally 
            { 
                CerrarConexion(); 
            }

            return carreras;
        }

        public bool InsertarCarrera(string nombre)
        {
            SqlCommand cmd = new SqlCommand("Registrar_carrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", nombre);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
