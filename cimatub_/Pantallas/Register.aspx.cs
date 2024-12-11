using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            if (!IsPostBack)
            {
                N_Carrera NC = new N_Carrera();
                ddCarreras.DataSource = NC.ListarCarreras();
                ddCarreras.DataValueField = "IdCarrera";
                ddCarreras.DataTextField = "Nombre";
                ddCarreras.DataBind();
            }
        }


        public void RegistrarUsuario(object sender, EventArgs e)
        {
            N_Usuario NU = new N_Usuario();

            int ALUMNO = 2;
            int DOCENTE = 1;

            int idTipoUsuario = ALUMNO;

            //if (rbDocenteSi.Checked)
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
                Foto = FileUploadControl.FileBytes
            };

            string resultado = NU.RegistrarUsuario(usuario);
            //lblRegistro.Text += resultado;


            if (idTipoUsuario == ALUMNO)
            {
                N_Alumno NA = new N_Alumno();
                E_Usuario usr = NU.BuscarUsuarioPorCorreo(correo);

                if (usr == null)
                {
                    //lblRegistro.Text += "Error al registrar alumno\n";
                    return;
                }

                E_Alumno alumno = new E_Alumno()
                {
                    IdCarrera = int.Parse(ddCarreras.SelectedValue),
                    IdUsuario = usr.IdUsuario
                };
                string res = NA.RegistrarAlumno(alumno);
                //lblRegistro.Text += res;
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            
        }
        protected void rbDocente_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbDocenteNo.Checked)
            {
                Div1.Visible = true; // Muestra el dropdown
            }
            //else
            {
                Div1.Visible = false; // Oculta el dropdown
            }
        }


        public void showDDCareer(object sender, EventArgs e)
        {

        }


    }
}