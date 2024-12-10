using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;
using System.Web.Services.Description;

namespace cimatub_.Pantallas
{
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //este usuario sera el que se usa en toda la pagina
                Session["IdUsuario"] = 3;

                //este id video sera obtenido pulsar boton de editar video
                Session["IdVideo"] = 23;


                int idUsuario = (int)Session["IdUsuario"];
                int idVideo = (int)Session["IdVideo"];

                N_Video NV = new N_Video();
                E_Video video = NV.BuscarVideoPorId(idVideo);


                if (video == null || idUsuario != video.IdUsuario)
                {
                    Response.Redirect("~/Pantallas/Inicio.aspx");
                }

                N_Materia NM = new N_Materia();

                E_Materia materia = NM.BuscarMateriaPorId(video.IdMateria);
                if (materia != null)
                {
                    tbMateria.Text = materia.Nombre;
                }

                tbTitulo.Text = video.Titulo;
                tbDescripcion.Text = video.Descripcion;
                imgVideo.ImageUrl = video.Img;

                N_Carrera NC = new N_Carrera();
                ddlCarrera.DataSource = NC.ListarCarreras();
                ddlCarrera.DataValueField = "IdCarrera";
                ddlCarrera.DataTextField = "Nombre";
                ddlCarrera.DataBind();

                ddlCarrera.SelectedValue = video.IdCarrera.ToString();

                cbVisibilidad.Checked = video.Visibilidad;
            }
        }



        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void RegistrarMateria(object sender, EventArgs e)
        {

        }

        //validar campos con asp
        protected void GuardarVideo(object sender, EventArgs e)
        {
            int idVideo = (int)Session["IdVideo"];

            string resultado = string.Empty;

            N_Materia NM = new N_Materia();

            E_Materia materia;

            if (NM.BuscarMateriaPorNombre(tbMateria.Text) == null)
            {
                materia = new E_Materia()
                {
                    IdCarrera = int.Parse(ddlCarrera.SelectedValue),
                    Nombre = tbMateria.Text
                };
                resultado += NM.InsertarMateria(materia);
            }

            materia = NM.BuscarMateriaPorNombre(tbMateria.Text);



            if (materia != null)
            {
                N_Video NV = new N_Video();

                E_Video videoEditado = NV.BuscarVideoPorId(idVideo);
                byte[] miniatura;

                if (imgMiniatura.HasFile)
                {
                    miniatura = imgMiniatura.FileBytes;
                }
                else
                {
                    miniatura = videoEditado.Miniatura;
                }

                E_Video video = new E_Video()
                {
                    IdVideo = idVideo,
                    IdCarrera = int.Parse(ddlCarrera.SelectedValue),
                    IdMateria = materia.IdMateria,
                    Titulo = tbTitulo.Text,
                    Descripcion = tbDescripcion.Text,
                    Miniatura = miniatura,
                    Visibilidad = cbVisibilidad.Checked,
                };

                resultado += NV.EditarVideo(video);
            }
            else
            {
                resultado += "Problema al modificar materia\n";
            }

            Response.Redirect(Request.Url.ToString());
        }

        protected void DescartarCambios(object sender, EventArgs e)
        {
            Response.Redirect("~/Pantallas/Inicio.aspx");
        }
    }
}