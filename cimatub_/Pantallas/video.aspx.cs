using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Datos simulados para los comentarios
                /*var comentarios = new List<dynamic>
                {
                    new { Usuario = "Juan Pérez", Comentario = "¡Excelente video!" },
                    new { Usuario = "Arturo Luna", Comentario = "Creo que hay un error en la resolución..." },
                    new { Usuario = "Fabián Arreola", Comentario = "Estoy de acuerdo con Arturo..." }
                };

                // Enlazar datos al Repeater
                RepeaterComments.DataSource = comentarios;
                RepeaterComments.DataBind();*/
            }
        }
    }
}