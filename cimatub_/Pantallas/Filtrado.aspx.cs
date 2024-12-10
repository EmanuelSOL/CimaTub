using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Filtrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string materiaBuscada = Request.QueryString["materia"];

                if (!string.IsNullOrEmpty(materiaBuscada))
                {
                    FiltrarPorMateria(materiaBuscada);
                }
                else
                {
                    MostrarMensaje("No se especificó ninguna materia para el filtrado.");
                }
            }
        }

        private void FiltrarPorMateria(string materiaBuscada)
        {
            try
            {
                N_Materia NM = new N_Materia();
                E_Materia materia = NM.BuscarMateriaPorNombre(materiaBuscada);

                if (materia != null)
                {
                    MostrarMensaje($"Filtrado realizado correctamente: Materia '{materia.Nombre}' encontrada.");
                    MostrarVideosRelacionados(materia.IdMateria);
                }
                else
                {
                    MostrarMensaje($"No se encontraron resultados para la materia: '{materiaBuscada}'.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en FiltrarPorMateria: {ex.Message}");
                MostrarMensaje("Ocurrió un error al intentar realizar el filtrado.");
            }
        }

        private void MostrarVideosRelacionados(int idMateria)
        {
            N_Video NC = new N_Video();
            List<E_Video> videosRelacionados = NC.FiltrarPorMateria(idMateria);

            Debug.WriteLine($"Número de videos relacionados encontrados: {videosRelacionados.Count}");

            lstVideos.DataSource = videosRelacionados;
            lstVideos.DataBind();
        }
        protected void VerVideo(object sender, ImageClickEventArgs e)
        {
            try
            {
                var imageButton = (ImageButton)sender;
                int idVideo = int.Parse(imageButton.CommandArgument.ToString());

                Response.Redirect($"VideoDetalle.aspx?idVideo={idVideo}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en VerVideo: {ex.Message}");
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            lblMateriaResultado.Text = mensaje;
        }
    }
}
