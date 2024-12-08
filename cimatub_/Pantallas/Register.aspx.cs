using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cbDocente_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void RegistrarUsuario(object sender, EventArgs e)
        {

        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                string filePath = Server.MapPath("~/Recursos/Imagenes/") + FileUploadControl.FileName;
                FileUploadControl.SaveAs(filePath);
                // Actualiza la lógica para usar la nueva imagen
            }
            else
            {
                // Manejar cuando no se selecciona ningún archivo
            }
        }
        protected void rbDocente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDocenteNo.Checked)
            {
                Div1.Visible = true; // Muestra el dropdown
            }
            else
            {
                Div1.Visible = false; // Oculta el dropdown
            }
        }


    }
}