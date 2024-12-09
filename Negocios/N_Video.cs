using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Net.Configuration;


using System.Web.UI.WebControls;
using System.Diagnostics;
using Google.Apis.Drive.v3;
using System.IO;


namespace Negocios
{
    public class N_Video
    {
        private D_Video DV;
        private D_Materia DM;
        public N_Video()
        {
            DV = new D_Video();
            DM = new D_Materia();
        }
    
        public string RegistrarVideo(E_Video video)
        {
            string msg = string.Empty;

            if (!DV.InsertarVideo(video))
            {
                msg += "Error al insertar video";
            }

            if (msg == string.Empty)
            {
                msg = "Video registrado";
            }

            return msg;
        }

        public List<E_Video> ListarDestacados()
        {
            return DV.ListarDestacados();
        }

        public List<E_Video> FiltrarPorMateria(int idMateria)
        {
            return DV.FiltrarPorMateria(idMateria);
        }

        public List<E_Video> FiltrarPorCarrera(int idCarrera)
        {
            return DV.FiltrarPorCarrera(idCarrera);
        }


        public async Task<string> getUrl(FileUpload video)
        {
            string url = string.Empty;
            try
            {
                GoogleDrive googleDrive = new GoogleDrive();

                url = await googleDrive.GetUrl(video.PostedFile);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return url;
        }

        public E_Video BuscarVideoPorId(int idVideo)
        {
            return DV.BuscarVideoPorId(idVideo);
        }

        public string EditarVideo(E_Video video)
        {
            string msg = string.Empty;


            if (!DV.EditarVideo(video))
            {
                msg += "Error al editar video\n";
            }

            if(msg ==  string.Empty)
            {
                msg += "Video editado correctamente\n";
            }

            return msg;
        }

        public List<E_Video> ListarHistorial(int idUsuario)
        {
            return DV.ListarVideosHistorial(idUsuario);
        }
    }
}
