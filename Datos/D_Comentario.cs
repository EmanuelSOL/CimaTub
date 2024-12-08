using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Datos
{
    public class D_Comentario : Conexion
    {
        public bool InsertarComentario(E_Comentario comentario)
        {
            SqlCommand cmd = new SqlCommand("InsertarComentario",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", comentario.IdUsuario);
            cmd.Parameters.AddWithValue("@IdVideo", comentario.IdVideo);
            cmd.Parameters.AddWithValue("@IdUsuario", comentario.Con);

            return false;
        }
    }
}
