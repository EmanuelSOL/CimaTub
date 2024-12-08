using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace cimatub_.Pantallas
{
    public partial class video : System.Web.UI.Page
    {
        public string VideoUrl { get; set; } = "https://www.youtube.com/embed/dQw4w9WgXcQ"; // URL del video
        public string UserProfileImage { get; set; } = "~/recursos/imagenes/user-profile.png"; // Imagen del usuario
        public string UserName { get; set; } = "Usuario Ejemplo"; // Nombre del usuario
        public string VideoTitle { get; set; } = "Título del Video de Ejemplo"; // Título del video
        public int Views { get; set; } = 12345; // Número de vistas
        public string VideoDescription { get; set; } = "Esta es una descripción de prueba para el video."; // Descripción
        public int LikesCount { get; set; } = 678; // Número de likes
        public int DislikesCount { get; set; } = 45; // Número de dislikes
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RepeaterComments.DataBind();
            }
        }

        // Manejar clic del botón "Me gusta"
        protected void btnLike_Click(object sender, EventArgs e)
        {
            LikesCount++;
            lblLikesCount.Text = LikesCount.ToString();
        }

        // Manejar clic del botón "No me gusta"
        protected void btnDislike_Click(object sender, EventArgs e)
        {
            DislikesCount++;
            lblDislikesCount.Text = DislikesCount.ToString();
        }

        // Manejar clic del botón "Enviar comentario"
        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewComment.Text))
            {

                RepeaterComments.DataBind();

                // Limpiar el cuadro de texto
                txtNewComment.Text = string.Empty;
            }
        }

        // Manejar clic del botón "Regresar"
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx"); // Cambia por la URL de tu página de inicio
        }
    }
}