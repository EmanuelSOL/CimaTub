using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

using System.Diagnostics;
using System.IO;

namespace cimatub_
{
    public partial class PruebaBackend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                N_Carrera NC = new N_Carrera();
                ddCarreras.DataSource = NC.ListarCarreras();
                ddCarreras.DataValueField = "IdCarrera";
                ddCarreras.DataTextField = "Nombre";
                ddCarreras.DataBind();
            }
        }
        public void ListarCarreras(object sender, EventArgs e)
        {

            N_Carrera c = new N_Carrera();


            List<E_Carrera> carreras = c.ListarCarreras();
            Debug.WriteLine(carreras.Count);
            gvCarreras.DataSource = carreras;
            gvCarreras.DataBind();

        }

        public void ListarMateriasPorIdCarrera(object sender, EventArgs e)
        {
            N_Materia NM = new N_Materia();

            int idCarrera = Convert.ToInt32(tbIdCarrera.Text);

            gvMaterias.DataSource = NM.ListarMateriasPorIdCarrera(idCarrera);
            gvMaterias.DataBind();
        }

        public void RegistrarCarrera(object sender, EventArgs e)
        {
            N_Carrera NC = new N_Carrera();

            string resultado = NC.RegistrarCarrera(tbRegCarrera.Text);

            if (resultado == string.Empty)
            {
                lblResRegCarrera.Text = "Carrera Registrada";
                return;
            }

            lblResRegCarrera.Text = resultado;
        }

        public void ListarDestacados(object sender, EventArgs e)
        {
            N_Video NC = new N_Video();

            gvDestacados.DataSource = NC.ListarDestacados();
            gvDestacados.DataBind();
        }

        public void ddCarreraSelect(object sender, EventArgs e)
        {
            int selectedValue = int.Parse(ddCarreras.SelectedValue);

            N_Materia NM = new N_Materia();

            ddMaterias.DataSource = NM.ListarMateriasPorIdCarrera(selectedValue);
            ddMaterias.DataValueField = "IdMateria";
            ddMaterias.DataTextField = "Nombre";
            ddMaterias.DataBind();
        }

        public void FiltrarPorCarrera(object sender, EventArgs e)
        {
            N_Video NV = new N_Video();

            int idCarrera = int.Parse(ddCarreras.SelectedValue);

            List<E_Video> videos = NV.FiltrarPorCarrera(idCarrera);

            lblVideosFiltrados.Text = "";
            gvVideosFiltrados.DataSource = null;

            if (videos.Count == 0)
            {
                lblVideosFiltrados.Text = "No hay videos para esa carrera";
            }
            else
            {
                gvVideosFiltrados.DataSource = videos;
            }

            gvVideosFiltrados.DataBind();
        }

        public void FiltrarPorMateria(object sender, EventArgs e)
        {
            N_Video NV = new N_Video();

            int idMateria = int.Parse(ddMaterias.SelectedValue);
            List<E_Video> videos = NV.FiltrarPorMateria(idMateria);

            lblVideosFiltrados.Text = "";
            gvVideosFiltrados.DataSource = null;

            if (videos.Count == 0)
            {
                lblVideosFiltrados.Text = "No hay videos para esa materi";
            }
            else
            {
                gvVideosFiltrados.DataSource = videos;
            }

            gvVideosFiltrados.DataBind();

        }

        public void RegistrarMateria(object sender, EventArgs e)
        {
            //usa la carrera que esta en el dropdown de carreras.
            E_Materia materia = new E_Materia()
            {
                IdCarrera = int.Parse(ddCarreras.SelectedValue),
                Nombre = tbRegMateria.Text
            };

            N_Materia NM = new N_Materia();

            string resultado = NM.InsertarMateria(materia);

            if (resultado == string.Empty)
            {
                lblRegMateria.Text = "Materia Registrada";
                return;
            }
            lblRegMateria.Text = resultado;

        }

        public void RegistrarUsuario(object sender, EventArgs e)
        {
            byte[] imagenBytes = img.FileBytes;

            string imagenBase64 = Convert.ToBase64String(imagenBytes);
            string imgTag = "<img src='data:image/jpeg;base64," + imagenBase64 + "' />";
        }
    }
}
