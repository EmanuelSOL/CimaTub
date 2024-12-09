using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
           }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {
            // Redirige al usuario a la página Login.aspx
            Response.Redirect("Login.aspx");
        }

        protected void Registrar(object sender, EventArgs e)
        {

        }

        protected void CerrarSesionn(object sender, EventArgs e)
        {

        }


    }
}
