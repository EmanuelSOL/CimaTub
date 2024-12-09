using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Filtrado : System.Web.UI.Page
    {
        protected void VerVideo(object sender, EventArgs e)
        {
            // Obtener el argumento del comando (ID del video)
            string videoId = ((ImageButton)sender).CommandArgument;

            // Redirigir a otra página con el ID del video
            Response.Redirect($"VerVideo.aspx?Id={videoId}");
        }
    }
}