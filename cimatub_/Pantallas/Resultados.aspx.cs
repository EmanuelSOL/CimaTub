using Entidades;
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
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ResultadoBusqueda"] == null)
                {
                    Response.Redirect("~/Pantallas/Inicio.aspx");
                }

                List<E_Video> videos = Session["ResultadoBusqueda"] as List<E_Video>;

                if(videos.Count < 1)
                {
                    lblNFound.Text = "No hay videos coincidentes";
                }

                lstVideos.DataSource = videos;
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