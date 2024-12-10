using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Pantallas/Login.aspx");
            }

            int idUsuario = (int)Session["IdUsuario"];

            N_Usuario NU = new N_Usuario();

            E_Usuario usuario = NU.BuscarUsuarioPorId(idUsuario);
           
            if(usuario == null)
            {
                Response.Redirect("~/Pantallas/Login.aspx");
            }

            N_TipoUsuario NTU = new N_TipoUsuario();

            imgProfile.ImageUrl = usuario.getImg();
            lblEmail.Text = usuario.Correo;
            lblRole.Text = NTU.BuscarNombreTipoUsuarioPorId(usuario.IdTipoUsuario);
            lblUserName.Text = usuario.Nombre;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
        protected void VerHistorial(object sender, EventArgs e)
        {
            Response.Redirect("~/Pantallas/Historial.aspx");
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["IdUsuario"] = null;
            Response.Redirect("~/Pantallas/Login.aspx");
        }
    }
}