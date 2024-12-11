using Entidades;
using Negocios;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Subir2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes inicializar valores aquí si es necesario
            }
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar lógica si es necesario
        }

        protected void RegistrarMateria(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica de registrar materia si es necesario
        }

        // Validar campos y guardar video
        protected void GuardarVideo(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(tbTitulo2.Text) || string.IsNullOrWhiteSpace(tbDescripcion2.Text))
            {
                lblEstadoVideo.Text = "Título y descripción son obligatorios.";
                lblEstadoVideo.CssClass = "error";
                return;
            }

            if (!fileUpload.HasFile)
            {
                lblEstadoVideo.Text = "Debes seleccionar un archivo de video.";
                lblEstadoVideo.CssClass = "error";
                return;
            }

            // Guarda el archivo de video
            string videoPath = Server.MapPath("~/Videos/" + fileUpload.FileName);
            fileUpload.SaveAs(videoPath); // Guarda el video en una carpeta en el servidor

            // Aquí iría la lógica de guardar el video en la base de datos (con la ruta o el archivo en sí)

            int idVideo = (int)Session["IdVideo"];
            string resultado = string.Empty;

            N_Materia NM = new N_Materia();
            E_Materia materia;

            // Verificar si la materia existe o crearla si no
            if (NM.BuscarMateriaPorNombre(tbMateria2.Text) == null)
            {
                materia = new E_Materia()
                {
                    IdCarrera = int.Parse(ddlCarrera2.SelectedValue),
                    Nombre = tbMateria2.Text
                };
                resultado += NM.InsertarMateria(materia);
            }

            materia = NM.BuscarMateriaPorNombre(tbMateria2.Text);

            if (materia != null)
            {
                N_Video NV = new N_Video();
                E_Video videoEditado = NV.BuscarVideoPorId(idVideo);
                byte[] miniatura;

                if (imgMiniatura2.HasFile)
                {
                    miniatura = imgMiniatura2.FileBytes;
                }
                else
                {
                    miniatura = videoEditado.Miniatura;
                }

                // Leer el archivo como un arreglo de bytes
                byte[] videoBytes = fileUpload.FileBytes;

                // Crear el objeto de video con los datos
                E_Video video = new E_Video()
                {
                    IdVideo = idVideo,
                    IdCarrera = int.Parse(ddlCarrera2.SelectedValue),
                    IdMateria = materia.IdMateria,
                    Titulo = tbTitulo2.Text,
                    Descripcion = tbDescripcion2.Text,
                    Miniatura = miniatura,
                    Visibilidad = cbVisibilidad.Checked,
                    //VideoData = videoBytes // Guarda el archivo binario directamente en la base de datos
                };

                // Llamar al método de negocio para guardar el video en la base de datos
                resultado += NV.EditarVideo(video);
                lblEstadoVideo.Text = "Video guardado exitosamente.";
                lblEstadoVideo.CssClass = "success"; // Asumiendo que tienes una clase 'success' para mostrar el mensaje de éxito.
            }
            else
            {
                lblEstadoVideo.Text = "Problema al modificar la materia.";
                lblEstadoVideo.CssClass = "error";
            }

            // Redirigir o refrescar la página
            Response.Redirect(Request.Url.ToString()); // Esto recarga la página
        }

        protected void DescartarCambios(object sender, EventArgs e)
        {
            // Redirigir a la página principal o a otra página según lo necesario
            Response.Redirect("~/Pantallas/Inicio.aspx");
        }
    }
}