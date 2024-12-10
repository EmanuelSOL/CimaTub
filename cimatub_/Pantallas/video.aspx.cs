using Entidades;
using Negocios;
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

        private int LIKE = 1;
        private int DISLIKE = 2;

        public string VideoUrl { get; set; } = "https://www.youtube.com/embed/dQw4w9WgXcQ"; // URL del video
        public string UserProfileImage { get; set; } = "~/recursos/imagenes/user-profile.png"; // Imagen del usuario
        public string UserName { get; set; } = "Usuario Ejemplo"; // Nombre del usuario
        public string VideoTitle { get; set; } = "Título del Video de Ejemplo"; // Título del video
        public int Views { get; set; } = 12345; // Número de vistas
        public string VideoDescription { get; set; } = "Esta es una descripción de prueba para el video."; // Descripción

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerIdVideo"] == null)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
            }

            if (!IsPostBack)
            {
                int idVideo = (int)Session["VerIdVideo"];
                
                N_Video NV = new N_Video();

                E_Video video = NV.BuscarVideoPorId(idVideo);
                if (video == null)
                {
                    return;
                }

                if (Session["IdUsuario"] == null)
                {
                    btnEditar.Visible = false;
                }
                else
                {
                    if ((int)Session["IdUsuario"] != video.IdUsuario)
                    {
                        btnEditar.Visible = false;
                    }
                }

                NV.IncrementarVisitas(idVideo);

                N_Usuario NU = new N_Usuario();

                E_Usuario usuario = NU.BuscarUsuarioPorId(video.IdUsuario);
                
                if(usuario == null)
                {
                    return;
                }

                VideoUrl = video.getPreView();
                UserProfileImage = usuario.getImg();
                UserName = usuario.Nombre;
                VideoTitle = video.Titulo;
                VideoDescription = video.Descripcion;

                N_Reaccion NR = new N_Reaccion();
                Views = video.Visitas;

                

                btnLike.Text = "Me gustó: " + Convert.ToString(NR.ContarLikes(video.IdVideo));
                btnDislike.Text = "No me gustó: " + Convert.ToString(NR.ContarDislikes(video.IdVideo));

                DataBind();

                // Cargar comentarios si fuera necesario
                rptComments.DataBind();


            }
           
        }

        // Manejar clic del botón "Me gusta"
        protected void Like(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Pantallas/Login.aspx");
            }

            if (Session["VerIdVideo"] == null)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
            }

            N_Reaccion NR = new N_Reaccion();

            int idVideo = (int)Session["VerIdVideo"];
            int idUsuario = (int)Session["IdUsuario"];
            E_Reaccion reaccion = new E_Reaccion()
            {
                IdVideo = idVideo,
                IdUsuario = idUsuario,
                IdTipoReaccion = LIKE,
            };

            NR.RegistrarReaccion(reaccion);

            btnLike.Text = "Me gustó: " + Convert.ToString(NR.ContarLikes(idVideo));
            btnDislike.Text = "No me gustó: " + Convert.ToString(NR.ContarDislikes(idVideo));

        }

        // Manejar clic del botón "No me gusta"
        protected void Dislike(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Pantallas/Login.aspx");
            }

            if (Session["VerIdVideo"] == null)
            {
                Response.Redirect("~/Pantallas/Inicio.aspx");
            }

            N_Reaccion NR = new N_Reaccion();

            int idVideo = (int)Session["VerIdVideo"];
            int idUsuario = (int)Session["IdUsuario"];
            E_Reaccion reaccion = new E_Reaccion()
            {
                IdVideo = idVideo,
                IdUsuario = idUsuario,
                IdTipoReaccion = DISLIKE,
            };

            NR.RegistrarReaccion(reaccion);

            btnLike.Text = "Me gustó: " + Convert.ToString(NR.ContarLikes(idVideo));
            btnDislike.Text = "No me gustó: " + Convert.ToString(NR.ContarDislikes(idVideo));
            
        }

        protected void Comentar(object sender, EventArgs e)
        {
           
        }

        // Manejar clic del botón "Regresar"
        protected void Regresar(object sender, EventArgs e)
        {
            Response.Redirect("~/Pantallas/Inicio.aspx");
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pantallas/Inicio.aspx");
        }
        protected void enviar_Click(object sender, EventArgs e)
        {
            // Limpiar el texto de búsqueda
            TextoBuscar.Text = string.Empty;
        }

        public void Editar(object sender, EventArgs e)
        {
            Response.Redirect("~/Pantallas/Editarr.aspx");
        }
    }
}