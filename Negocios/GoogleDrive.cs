using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;


using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Diagnostics;

namespace Negocios
{
    public class GoogleDrive
    {
        private static DriveService InitializeDriveServiceAsync()
        {
            string clientId = WebConfigurationManager.AppSettings["GoogleClientId"];
            string clientSecret = WebConfigurationManager.AppSettings["GoogleClientSecret"];
            string refreshToken = WebConfigurationManager.AppSettings["GoogleRefreshToken"];

            Console.WriteLine(clientId);

            var tokenResponse = new Google.Apis.Auth.OAuth2.Responses.TokenResponse
            {
                RefreshToken = refreshToken
            };

            var credential = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret
                    }
                }), "user", tokenResponse);

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "sucop",
            });
        }

        public async Task<string> GetUrl(HttpPostedFile video)
        {
            string url = string.Empty;

            try
            {
                // Inicializa el servicio de Google Drive
                var driveService = InitializeDriveServiceAsync();

                // Subir archivo a Google Drive
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = video.FileName,
                    MimeType = "video/mp4" // Cambia el tipo MIME según el tipo de archivo que estés subiendo
                };

                // Crear un stream de los datos del archivo
                using (var stream = video.InputStream)
                {
                    // Subir el archivo
                    FilesResource.CreateMediaUpload request = driveService.Files.Create(fileMetadata, stream, "video/mp4");
                    request.Upload(); // Subir el archivo

                    // Obtener el ID del archivo subido
                    var file = request.ResponseBody;

                    // Cambiar los permisos del archivo a público
                    var permission = new Google.Apis.Drive.v3.Data.Permission()
                    {
                        Type = "anyone",
                        Role = "reader"
                    };

                    // Agregar permiso para que sea público
                    await driveService.Permissions.Create(permission, file.Id).ExecuteAsync();

                    // Obtener la URL del archivo
                    url = $"https://drive.google.com/file/d/{file.Id}/view?usp=sharing";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return url;
        }
    }
}
