using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuario
    {
        private int _idUsuario;
        private int _idTipoUsuario;
        private string _correo;
        private string _contarsena;
        private string _nombre;
        private byte[] _foto;


        public E_Usuario()
        {
            IdUsuario = 0;
            IdTipoUsuario = 0;
            Correo = string.Empty;
            Contrasena = string.Empty;
            Nombre = string.Empty;
            Foto = null;
        }
        public E_Usuario(int idUsuario, int idTipoUsuario, string correo, string contrsena, string nombre, byte[] foto)
        {
            IdUsuario = idUsuario;
            IdTipoUsuario = idTipoUsuario;
            Correo = correo;
            Contrasena = contrsena;
            Nombre = nombre;
            Foto = foto;
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Contrasena { get => _contarsena; set => _contarsena = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public byte[] Foto { get => _foto; set => _foto = value; }

        public string getImg()
        {
            string base64String = Convert.ToBase64String(Foto);

            return "data:image/jpeg;base64," + base64String;
        }
    }
}
