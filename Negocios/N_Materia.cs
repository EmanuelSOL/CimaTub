﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidades;

namespace Negocios
{
     public class N_Materia
    {
        private D_Materia DM;
        public N_Materia()
        {
            DM = new D_Materia();
        }

        public List<E_Materia> ListarMateriasPorIdCarrera(int idCarrera)
        {
            return DM.ListarMateriasPorIdCarrera(idCarrera);
        }

        public string InsertarMateria(E_Materia materia) 
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(materia.Nombre))
            {
                msg += "Nombre invalido\n";
            }

            if (msg == string.Empty && !DM.InsertarMateria(materia))
            {
                msg += "Error al insertar materia\n";
            }

            return msg;
        }
    }
}
