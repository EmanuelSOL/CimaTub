using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Reaccion
    {
        private D_Reaccion DR;
        public N_Reaccion() 
        {
           DR = new D_Reaccion();
        }

        public string getReaccion(E_Reaccion reaccion)
        {
            return DR.BuscarReaccionDeUsuario(reaccion);
        }

        public void RegistrarReaccion(E_Reaccion reaccion)
        {
            if (!DR.InsertarReaccion(reaccion))
            {
                Debug.WriteLine("Eror al insertar reaccion\n");
            }
        }

        public int ContarLikes(int idVideo)
        {
            return DR.ContarLikes(idVideo);
        }

        public int ContarDislikes(int idVideo) 
        {
            return DR.ContarDislikes(idVideo);    
        }
    }
}
