using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Comentario
    {
        private int _idComentario;
        private int _idUsuario;
        private int _idVideo;
        private string _contenido;

        public E_Comentario()
        {
            IdComentario = 0;
            IdUsuario = 0;
            IdVideo = 0;
            Contenido = string.Empty;
        }

        public E_Comentario(int idComentario, int idUsuario, int idVideo, string contenido)
        {
            IdComentario = idComentario;
            IdUsuario = idUsuario;
            IdVideo = idVideo;
            Contenido = contenido;
        }

        public int IdComentario { get => _idComentario; set => _idComentario = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdVideo { get => _idVideo; set => _idVideo = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
    }
}
