using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_TipoUsuario
    {
        private int _idTipoUsuario;
        private string _descripcion;

        public E_TipoUsuario(int idTipoUsuario, string descripcion)
        {
            IdTipoUsuario = idTipoUsuario;
            Descripcion = descripcion;
        }

        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
