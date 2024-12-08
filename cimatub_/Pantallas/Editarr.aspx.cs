using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarreras();
            }
        }

        private void CargarCarreras()
        {
            
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GuardarVideo(object sender, EventArgs e)
        {
            // Lógica para guardar los cambios del video en la base de datos
        }

        protected void DescartarCambios(object sender, EventArgs e)
        {
            // Lógica para descartar los cambios y redirigir a otra página
        }
    }
}