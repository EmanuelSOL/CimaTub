using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Net.Configuration;

namespace Negocios
{
    public class N_Video
    {
        private D_Video ND;
        public N_Video()
        {
            ND = new D_Video();
        }
    
        public string RegistrarVideo(E_Video video)
        {
            string msg = string.Empty;

            if (!ND.InsertarVideo(video))
            {
                msg += "Error al insertar video";
            }

            if (msg == string.Empty)
            {
                msg = "Video registrado";
            }

            return msg;
        }

        public List<E_Video> ListarDestacados()
        {
            return ND.ListarDestacados();
        }

        public List<E_Video> FiltrarPorMateria(int idMateria)
        {
            return ND.FiltrarPorMateria(idMateria);
        }

        public List<E_Video> FiltrarPorCarrera(int idCarrera)
        {
            return ND.FiltrarPorCarrera(idCarrera);
        }
    }
}
