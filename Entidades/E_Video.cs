using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Video
    {
        private int _idVideo;
        private int _idUsuario;
        private int _idCarrera;
        private int _idMateria;
        private string _titulo;
        private string _descripcion;
        private string _url;
        private int _visitas;
        private byte[] _miniatura;
        private bool _visibilidad;
        private string _img;
        private string _preview;

        public E_Video(int idVideo, int idUsuario, int idCarrera, int idMateria, string titulo, string descripcion, string url, int visitas, byte[] miniatura, bool visibilidad)
        {
            IdVideo = idVideo;
            IdUsuario = idUsuario;
            IdCarrera = idCarrera;
            IdMateria = idMateria;
            Titulo = titulo;
            Descripcion = descripcion;
            Url = url;
            Visitas = visitas;
            Miniatura = miniatura;
            Visibilidad = visibilidad;
            Img = getImg();
            Preview = getPreView();
        }

        public E_Video()
        {
            IdVideo = 0;
            IdUsuario = 0;
            IdCarrera = 0;
            IdMateria = 0;
            Titulo = string.Empty;
            Descripcion = string.Empty;
            Url = string.Empty;
            Visitas = 0;
            Miniatura = null;
            Visibilidad = true;
            Img = string.Empty;
        }

        public int IdVideo { get => _idVideo; set => _idVideo = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdCarrera { get => _idCarrera; set => _idCarrera = value; }
        public int IdMateria { get => _idMateria; set => _idMateria = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Url { get => _url; set => _url = value; }
        public int Visitas { get => _visitas; set => _visitas = value; }
        public byte[] Miniatura { get => _miniatura; set => _miniatura = value; }
        public bool Visibilidad { get => _visibilidad; set => _visibilidad = value; }
        public string Img { get => _img; set => _img = value; }
        public string Preview { get => _preview; set => _preview = value; }

        public string getImg()
        {
            string base64String = Convert.ToBase64String(Miniatura);

            return "data:image/jpeg;base64," + base64String;
        }

        public string getPreView()
        {
            string videoUrl = Url;

            var fileId = videoUrl.Split('/')[5];

            return $"https://drive.google.com/file/d/{fileId}/preview";
        }
    }
}
