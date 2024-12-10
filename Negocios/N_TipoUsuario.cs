using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_TipoUsuario
    {
        private D_TipoUsuario DTU;

        public N_TipoUsuario()
        {
            DTU = new D_TipoUsuario();
        }

        public string BuscarNombreTipoUsuarioPorId(int idTipoUsuario)
        {
            return DTU.BuscarNombreTipoUsuarioPorId(idTipoUsuario);
        }

    }
}
