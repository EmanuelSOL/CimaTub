using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;

namespace Negocios
{
    public class N_Carrera
    {
        private D_Carrera DC;
        public N_Carrera() 
        {
            DC = new D_Carrera();
        }

        public List<E_Carrera> ListarCarreras()
        {
            return DC.ListarCarreras();
        }

        public string RegistrarCarrera(string nombre)
        {
            string msg = string.Empty;
            if (string.IsNullOrEmpty(nombre))
            {
                msg += "Nombe invalido\n";
            }

            if(msg == string.Empty && !DC.InsertarCarrera(nombre))
            {
                msg += "Error al registrar carrera\n";
            }


            return msg;
        }
    }
}
