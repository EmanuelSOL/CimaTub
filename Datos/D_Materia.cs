using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Entidades;
using System.Diagnostics;

namespace Datos
{
    public class D_Materia : Conexion
    {
        public List<E_Materia> ListarMateriasPorIdCarrera(int idCarrera)
        {
            List<E_Materia> materias = new List<E_Materia>();
            SqlCommand cmd = new SqlCommand("Listar_materias_por_carrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCarrera",idCarrera);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Materia materia = new E_Materia()
                    {
                        IdMateria = (int)reader["IdMateria"],
                        IdCarrera = (int)reader["IdCarrera"],
                        Nombre = (string)reader["Nombre"]
                    };
                    materias.Add(materia);
                }
            }
            catch (Exception ex) 
            {
                Debug.Write(ex.ToString());
            }
            finally 
            {
                CerrarConexion();
            }

            return materias;

        }

        public bool InsertarMateria(E_Materia materia)
        {
            SqlCommand cmd = new SqlCommand("InsertarMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCarrera",materia.IdCarrera);
            cmd.Parameters.AddWithValue("@Nombre",materia.Nombre);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
