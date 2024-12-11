using Entidades;
using Negocios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Security.Cryptography.X509Certificates;

namespace cimatub_.Pantallas
{
    public partial class SubirVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
            }

            int idUsuario = (int)Session["IdUsuario"];

            N_Alumno NA = new N_Alumno();

            if(NA.BuscarAlumnoPorIdUsuario(idUsuario) != null)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
            }

            if (!IsPostBack)
            {
                N_Carrera NC = new N_Carrera();

                ddlCarrera2.DataSource = NC.ListarCarreras();
                ddlCarrera2.DataTextField = "Nombre";
                ddlCarrera2.DataValueField = "IdCarrera";
                ddlCarrera2.DataBind();
            }
        }

        protected void ddlCarreraSelect(object sender, EventArgs e)
        {
            N_Materia NC = new N_Materia();

            int idCarrera = int.Parse(ddlCarrera2.SelectedValue);

            List<E_Materia> materias = NC.ListarMateriasPorIdCarrera(idCarrera);

            if(materias.Count > 1)
            {
                ddMaterias.Items.Add(new ListItem("No hay materias en esta carrera", ""));
                return;
            }
            ddMaterias.DataSource = materias;
            ddMaterias.DataTextField = "Nombre";
            ddMaterias.DataValueField = "IdMateria";
            ddMaterias.DataBind();
        }

        protected void RegistrarMateria(object sender, EventArgs e)
        {
            Debug.WriteLine("Registrando materia");
            //usa la carrera que esta en el dropdown de carreras.
            E_Materia materia = new E_Materia()
            {
                IdCarrera = int.Parse(ddlCarrera2.SelectedValue),
                Nombre = tbMateria2.Text
            };

            N_Materia NM = new N_Materia();

            string resultado = NM.InsertarMateria(materia);
            Debug.WriteLine(resultado);
            //lblResultadoMateria.Text = resultado;
        }

        public async void SubirVideoCT(object sender, EventArgs e)
        {
            lblRegistroVideo.Text = string.Empty;
            int idUsuario = 3;

            N_Video NC = new N_Video();
            N_Materia NM = new N_Materia();

            if(!CheckFiles())
            {
                return;
            }

            E_Materia materia = NM.BuscarMateriaPorNombre(tbMateria2.Text);

            if (materia == null) 
            {
                lblRegistroVideo.Text = "Materia no válida";
                return;
            }

            string url = await NC.getUrl(fileVideo);

            E_Video video = new E_Video()
            {
                IdUsuario = idUsuario,
                IdCarrera = int.Parse(ddlCarrera2.SelectedValue),
                IdMateria = materia.IdMateria,
                Titulo = tbTitulo2.Text,
                Descripcion = tbDescripcion2.Text,
                Url = url,
                Miniatura = imgMiniatura.FileBytes,
                Visibilidad = !cbVisibilidad.Checked,
            };

            string resultado = NC.RegistrarVideo(video);

            
            if(resultado == string.Empty)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
                return;
            }
            lblRegistroVideo.Text = resultado;
        }

        public bool CheckFiles()
        {
            
            if(!fileVideo.HasFile)
            {
                lblRegistroVideo.Text = "Video no cargado";
                return false;
            }

            if(!imgMiniatura.HasFile)
            {
                lblRegistroVideo.Text = "Miniatura no cargada";
                return false;
            }

            string videoExtension = Path.GetExtension(fileVideo.FileName).ToLower();
            string[] videoExtensionesPermitidas = { ".mp4", ".avi", ".mov", ".mkv" };
            if (!videoExtensionesPermitidas.Contains(videoExtension))
            {
                lblRegistroVideo.Text = "Formato de video no permitido";
                return false;
            }


            string miniaturaExtension = Path.GetExtension(imgMiniatura.FileName).ToLower();
            string[] imagenExtensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };
            if (!imagenExtensionesPermitidas.Contains(miniaturaExtension))
            {
                lblRegistroVideo.Text = "Formato de miniatura no permitido";
                return false;
            }

            return true;
        }
    }
}