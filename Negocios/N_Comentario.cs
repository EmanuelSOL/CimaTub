using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Comentario
    {
        private D_Comentario DC;

        public N_Comentario()
        {
            DC = new D_Comentario();
        }

        public bool RegistrarComentario(E_Comentario comentario)
        {
            return DC.InsertarComentario(comentario);
        }

        public List<E_Comentario> ListarComentariosVideo(int idVideo)
        {
            return DC.ListarComentariosVideo(idVideo);
        }
    }
}
