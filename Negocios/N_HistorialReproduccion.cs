using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Negocios
{
    public class N_HistorialReproduccion
    {
        private D_HistorialReproduccion DH;

        public N_HistorialReproduccion()
        {
            DH = new D_HistorialReproduccion();
        }

        //esta funcion debe ser llamada en onload if !PostBack
        public void RegistrarHistorial(E_HistorialReproduccion histoial)
        {
            if (!DH.InsertarHistorialReproduccion(histoial))
            {
                Debug.WriteLine("Error al registrar historial");
            }
        }

        
    }
}
