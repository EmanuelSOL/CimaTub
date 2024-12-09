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
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {
            // Redirige al usuario a la página Login.aspx
            Response.Redirect("Login.aspx");
        }

        protected void Registrar(object sender, EventArgs e)
        {

        }

        protected void CerrarSesionn(object sender, EventArgs e)
        {

        }
    }

    public class Carrera
    {
        public string CarreraNombre { get; set; }
        public List<string> Materias { get; set; }
    }
}
