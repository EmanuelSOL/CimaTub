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
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
        protected void VerHistorial(object sender, EventArgs e)
        {

        }
        protected void CerrarSesion(object sender, EventArgs e)
        {

        }
    }
}