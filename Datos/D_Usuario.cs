using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;

namespace Datos
{
    public class D_Usuario : Conexion
    {
        public bool InsertarUsuario(E_Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand("RegistrarUsuario", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.IdTipoUsuario);
            cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
            cmd.Parameters.AddWithValue("@Contraseña", usuario.Contrasena);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@Foto", usuario.Foto);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public E_Usuario BuscarUsuarioPorCorreo(string correo)
        {
            E_Usuario usuario = null;
            SqlCommand cmd = new SqlCommand("BuscarUsuarioPorCorreo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Correo", correo);

            try
            {
                AbrirConexion();
                SqlDataReader reader =  cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new E_Usuario()
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        IdTipoUsuario = (int)reader["IdTipoUsuario"],
                        Nombre = (string)reader["Nombre"],
                        Correo = (string)reader["Correo"],
                        Contrasena = (string)reader["Contrasena"],
                        Foto = (byte[])reader["Foto"]
                    };
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return usuario;
        }

        public E_Usuario BuscarUsuarioPorId(int idUsuario)
        {
            E_Usuario usuario = null;
            SqlCommand cmd = new SqlCommand("BuscarUsuarioPorId", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new E_Usuario()
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        IdTipoUsuario = (int)reader["IdTipoUsuario"],
                        Nombre = (string)reader["Nombre"],
                        Correo = (string)reader["Correo"],
                        Contrasena = (string)reader["Contrasena"],
                        Foto = (byte[])reader["Foto"]
                    };
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return usuario;
        }
    }
}
