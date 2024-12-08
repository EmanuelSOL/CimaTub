using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Reaccion
    {
        private int _idReaccion;
        private int _idVideo;
        private int _idUsuario;
        private int _idTipoReaccion;

        public E_Reaccion()
        {
            IdReaccion = 0;
            IdVideo = 0;
            IdUsuario = 0;
            IdTipoReaccion = 0;
        }

        public E_Reaccion(int idReaccion,int idVideo, int idUsuario, int idTipoReaccion)
        {
            IdReaccion = idReaccion;
            IdVideo = idVideo;
            IdUsuario = idUsuario;
            IdTipoReaccion = idTipoReaccion;
        }

        public int IdReaccion { get => _idReaccion; set => _idReaccion = value; }
        public int IdVideo { get => _idVideo; set => _idVideo = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdTipoReaccion { get => _idTipoReaccion; set => _idTipoReaccion = value; }
    }
}
