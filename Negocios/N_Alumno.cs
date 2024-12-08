using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Alumno
    {
        private D_Alumno DA;
        
        public N_Alumno() 
        {
            DA = new D_Alumno();
        }

        public string RegistrarAlumno(E_Alumno alumno)
        {
            string msg = string.Empty;



            if (!DA.InsertarAlumno(alumno)) 
            {
                msg += "Error al registrar alumno\n";
            }

            if (msg == string.Empty) 
            {
                msg = "Alumno registrado\n";
            }

            return msg;
        }
    }
}
