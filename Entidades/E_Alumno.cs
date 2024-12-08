using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Alumno
    {
        private int _idAlumno;
        private int _idUsuario;
        private int _idCarrera;

        public E_Alumno()
        {
            IdAlumno = 0;
            IdUsuario = 0;
            IdCarrera = 0;
        }

        public E_Alumno(int idAlumno, int idUsuario, int idCarrera)
        {
            IdAlumno = idAlumno;
            IdUsuario = idUsuario;
            IdCarrera = idCarrera;
        }

        public int IdAlumno { get => _idAlumno; set => _idAlumno = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdCarrera { get => _idCarrera; set => _idCarrera = value; }
    }
}
