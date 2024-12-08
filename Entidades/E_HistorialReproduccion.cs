using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_HistorialReproduccion
    {
        private int _idReproduccion;
        private int _idUsuario;
        private int _idVideo;

        public E_HistorialReproduccion()
        {
            IdReproduccion = 0;
            IdUsuario = 0;
            IdVideo = 0;
        }

        public E_HistorialReproduccion(int idReproduccion, int idUsuario, int idVideo)
        {
            IdReproduccion = idReproduccion;
            IdUsuario = idUsuario;
            IdVideo = idVideo;
        }

        public int IdReproduccion { get => _idReproduccion; set => _idReproduccion = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdVideo { get => _idVideo; set => _idVideo = value; }
    }
}
