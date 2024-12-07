using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Carrera
    {
        private int _idCarrera;
        private string _nombre;


        public E_Carrera()
        {
            IdCarrera = 0;
            Nombre = string.Empty;
        }

        public E_Carrera(int idCarrera, string nombre)
        {
            IdCarrera = idCarrera;
            Nombre = nombre;
        }

        public int IdCarrera { get => _idCarrera; set => _idCarrera = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
