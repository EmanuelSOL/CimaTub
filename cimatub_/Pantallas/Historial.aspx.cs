using Negocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
            }

            if (!IsPostBack)
            {
                int idUsuario = (int)Session["IdUsuario"];

                N_Video NV = new N_Video();
                lstVideos.DataSource = NV.ListarHistorial(idUsuario);
                lstVideos.DataBind();
            }
        }

        public void VerVideo(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;

            if (btn != null)
            {
                Session["VerIdVideo"] = int.Parse(btn.CommandArgument);
                Response.Redirect("~/Pantallas/video.aspx");
            }
        }

        public void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("~/Pantallas/Inicio.aspx");
        }
    }
}