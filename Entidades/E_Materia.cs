using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Materia
    {
        private int _idMateria;
        private int _idCarrera;
        private string _nombre;

        public E_Materia()
        {
            IdMateria = 0;
            IdCarrera = 0;
            Nombre = string.Empty;
        }

        public E_Materia(int idMateria, int idCarrera, string nombre)
        {
            IdMateria = idMateria;
            IdCarrera = idCarrera;
            Nombre = nombre;
        }

        public int IdMateria { get => _idMateria; set => _idMateria = value; }
        public int IdCarrera { get => _idCarrera; set => _idCarrera = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
