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

                lblCarrera.Text = ddCarreras.SelectedItem.Text;

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

            lblResRegCarrera.Text = NC.RegistrarCarrera(tbRegCarrera.Text);

        }

        public void ListarDestacados(object sender, EventArgs e)
        {
            N_Video NC = new N_Video();
            rptVideos.DataSource = NC.ListarDestacados();
            rptVideos.DataBind();

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

            lblRegMateria.Text = NM.InsertarMateria(materia);

        }

        public void RegistrarUsuario(object sender, EventArgs e)
        {
            int ALUMNO = 2;
            int DOCENTE = 1;

            int idTipoUsuario = ALUMNO;

            if (cbDocente.Checked)
            {
                idTipoUsuario = DOCENTE;
            }

            string correo = tbCorreo.Text;
            string contraseña = tbContraseña1.Text;
            E_Usuario usuario = new E_Usuario() 
            {
                IdTipoUsuario = idTipoUsuario,
                Correo = correo,
                Contrasena = contraseña,
                Nombre = tbNombreCompleto.Text,
                Foto = img.FileBytes
            };

            N_Usuario NU = new N_Usuario();

            lblRegistro.Text += NU.RegistrarUsuario(usuario);


            if (idTipoUsuario == ALUMNO)
            {
                N_Alumno NA = new N_Alumno();
                E_Usuario usr = NU.BuscarUsuarioPorCorreo(correo);

                if (usr == null)
                {
                    lblRegistro.Text += "Error al registrar alumno\n";
                    return;
                }

                E_Alumno alumno = new E_Alumno()
                {
                    IdCarrera = int.Parse(ddCarreras.SelectedValue),
                    IdUsuario = usr.IdUsuario
                };



                lblRegistro.Text += NA.RegistrarAlumno(alumno);


            }



        }

   
        public async void SubirVideo(object sender, EventArgs e)
        {
            lblRegVideo.Text = string.Empty;
            //el id usuario sera obtenido de la sesion
            int idUsuario = 3;

            N_Video NC = new N_Video();

            string url = await NC.getUrl(fileVideo);

            E_Video video = new E_Video()
            {
                IdUsuario = idUsuario,
                IdCarrera = int.Parse(ddCarreras.SelectedValue),
                IdMateria = int.Parse(ddCarreras.SelectedValue),
                Titulo = tbTitulo.Text,
                Descripcion = tbDescripcion.Text,
                Url = url,
                Miniatura = miniatura.FileBytes,
                Visibilidad = !cbOculto.Checked,
            };


            lblRegVideo.Text = NC.RegistrarVideo(video);
        }

        public void Login(object sender, EventArgs e)
        {
            N_Usuario NU = new N_Usuario();

            string correo = tbLoginCorreo.Text;
            string contraseña = tbLoginContrasena.Text;
            string resultado = NU.Login(correo,contraseña);


            if (resultado == string.Empty)
            {
                //redirigir aqui
                //ahora se muestra la foto para comprobar que se logueo
                E_Usuario usuario = NU.BuscarUsuarioPorCorreo(correo);
                imgPerfil.ImageUrl = usuario.getImg();
                return;
            }

            lblLogin.Text = resultado;
        }

    }
}
