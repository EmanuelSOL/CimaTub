using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                N_Video NC = new N_Video();
                ListViewDestacados.DataSource = NC.ListarDestacados();
                ListViewDestacados.DataBind();

                ListViewRecomendados.DataSource = NC.ListarDestacados();
                ListViewRecomendados.DataBind();
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
    }

}