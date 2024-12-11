using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace cimatub_
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgLogo.ImageUrl = ResolveUrl("~/recursos/imagenes/LOGOCIMATUBE2.png");

                N_Carrera NC = new N_Carrera();

                List<E_Carrera> carreras = NC.ListarCarreras();

                N_Materia NM = new N_Materia();

                var strCarreras = new List<Carrera>();

                foreach (E_Carrera carrera in carreras)
                {
                    List<E_Materia> materias = NM.ListarMateriasPorIdCarrera(carrera.IdCarrera);

                    List<string> strMaterias = new List<string>();

                    foreach (E_Materia materia in materias)
                    {
                        strMaterias.Add(materia.Nombre);
                    }

                    Carrera c = new Carrera()
                    {
                        CarreraNombre = carrera.Nombre,
                        Materias = strMaterias
                    };

                    strCarreras.Add(c);
                }


                careerList.DataSource = strCarreras;
                careerList.DataBind();
            }

            if (Session["IdUsuario"] != null)
            {
                int idUsuario = (int)Session["IdUsuario"];
                N_Usuario NU = new N_Usuario();
                E_Usuario usuario = NU.BuscarUsuarioPorId(idUsuario);
                if (usuario != null)
                {
                    userImg.ImageUrl = usuario.getImg();
                    lblUserName.Text = usuario.Nombre;

                }
                sincuenta.Visible = false;
                concuenta.Visible = true;

                CheckPanelAdmin(idUsuario);
            }
            else
            {
                sincuenta.Visible = true;
                concuenta.Visible = false;
            }
        }

        protected void Buscar(object sender, EventArgs e)
        {
            string texto = tbBuscar.Text;
            if(string.IsNullOrEmpty(texto))
            {
                return;
            }

            N_Video NV = new N_Video();
            List<E_Video> videos = NV.ListarVideosPorTexto(texto);
            
            Session["ResultadoBusqueda"] = videos;
            Response.Redirect("~/Pantallas/Resultados.aspx");
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            tbBuscar.Text = string.Empty;
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");
        }

        protected void Registrar(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void CerrarSesionn(object sender, EventArgs e)
        {
            Session["IdUsuario"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void VerPerfil(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        public void CheckPanelAdmin(int idUsuario)
        {
            N_TipoUsuario NT = new N_TipoUsuario();

            string tipo = NT.BuscarNombreTipoUsuarioPorId(idUsuario);

            if(tipo == "SuperUsuario")
            {
                Button2.Visible = true;
                dividerAdmin.Visible = true;
            }
        }

        public void Inicio(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }

    public class Carrera
    {
        public string CarreraNombre { get; set; }
        public List<string> Materias { get; set; }
    }
}