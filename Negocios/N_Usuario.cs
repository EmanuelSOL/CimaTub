using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using BCrypt.Net;
namespace Negocios
{
    public class N_Usuario
    {
        private D_Usuario DU;
        public N_Usuario()
        {
            DU = new D_Usuario();
        }

        public string RegistrarUsuario(E_Usuario usuario)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                msg += "Nombre requerido\n";
            }

            if (string.IsNullOrEmpty(usuario.Contrasena))
            {
                msg += "Contraseña requerida\n";
            }

            //no implementado
            usuario.Contrasena = EncryptPassword(usuario.Contrasena);


            //podemos aplicar expresion regular de ser necesario
            if (string.IsNullOrEmpty(usuario.Correo) || !usuario.Correo.EndsWith("@uabc.edu.mx"))
            {
                msg += "Correo invalido\n";
            }

            if (DU.BuscarUsuarioPorCorreo(usuario.Correo) != null)
            {
                msg += "Correo ya registrado\n";
            }

            if (msg == string.Empty && !DU.InsertarUsuario(usuario))
            {
                msg += "Error al registrar usuario\n";
            }

            if (msg == string.Empty)
            {
                msg = "Usuario registrado\n";
            }

            return msg;

        }

        //si devuelve string vacia se logueo, no es necesario enviar mensaje
        //ya que sera redirigido
        public string Login(string mail, string password)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(mail))
            {
                return "Correo requerido\n";
            }

            if (string.IsNullOrEmpty(password))
            {
                return "Contraseña requerida\n";
            }

            E_Usuario usuario = DU.BuscarUsuarioPorCorreo(mail);

            if (usuario == null)
            {
                msg += "Correo no registrado\n";
            }

            if (usuario != null && !ValidatePassword(password, usuario.Contrasena))
            {
                msg += "Credenciales invalidas\n";
            }

            if (msg == string.Empty)
            {
                Debug.WriteLine("Logeado");
            }

            return msg;
        }

        //deberiamos encriptar contraseña aqui
        public string EncryptPassword(string password)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Debug.WriteLine(hashedPassword);

            return hashedPassword;
        }

        public bool ValidatePassword(string password, string encrypted_password)
        {
            Debug.WriteLine(encrypted_password);
            return BCrypt.Net.BCrypt.Verify(password, encrypted_password);
        }

        public E_Usuario BuscarUsuarioPorCorreo(string mail)
        {
            return DU.BuscarUsuarioPorCorreo(mail);
        }

        public E_Usuario BuscarUsuarioPorId(int idUsuario)
        {
            return DU.BuscarUsuarioPorId(idUsuario);
        }
    }
}
