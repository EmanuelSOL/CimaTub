using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using System.Diagnostics;

namespace cimatub_.Pantallas
{
    public partial class Login : System.Web.UI.Page
    {
        private N_Usuario NU = new N_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["IdUsuario"] = null;
            }
        }
        protected void login(object sender, EventArgs e)
        {
            string resultado = NU.Login(txtEmail.Text, txtPassword.Text);


            if (resultado == string.Empty)
            {
                E_Usuario usuario = NU.BuscarUsuarioPorCorreo(txtEmail.Text);

                if (usuario != null)
                {
                    Debug.WriteLine(usuario.IdUsuario);
                    Session["IdUsuario"] = usuario.IdUsuario;
                    Response.Redirect("~/Pantallas/Inicio.aspx");
                }

                lblError.Text += "Error al iniciar sesión\n";
            }

            lblError.Text = resultado;
            Debug.WriteLine(resultado);


        }
        public void SinCuenta(object sender, EventArgs e)
        {
            txtEmail.Text = " ";
            txtPassword.Text = " ";
            Session["IdUsuario"] = null;
            Response.Redirect("~/Pantallas/Inicio.aspx");
        }
    } 
}
