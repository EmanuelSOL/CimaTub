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

namespace Negocios
{
    public class GoogleDriveService
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

        public static async Task<string> UploadFileToDrive(HttpPostedFile file, string name)
        {
            string parentFolderId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";  // Aquí pon el ID de la carpeta predeterminada

            return await UploadFileOnFolderAsync(file.InputStream, file.ContentType, name ?? file.FileName, parentFolderId);
        }

        public static async Task<string> UploadFileToDriveWithUniqueName(HttpPostedFile file, String ext, string route)
        {
            return await UploadFileOnFolderAsync(file.InputStream, file.ContentType, $"{Guid.NewGuid().ToString()}.{ext}", route);
        }

        public static async Task<string> UploadFileOnFolderAsync(Stream fileStream, string mimeType, string name, string parentFolderId)
        {
            var driveService = InitializeDriveServiceAsync();  // Inicializa el servicio de Drive

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = name,
                Parents = new List<string> { parentFolderId }  // Especificamos el ID de la carpeta donde subir el archivo
            };

            var createRequest = driveService.Files.Create(fileMetadata, fileStream, mimeType);
            var response = await createRequest.UploadAsync();

            return createRequest.ResponseBody.Id;  // Devuelve el ID del archivo subido
        }

        private static async Task<string> CreateOrFindFolderAsync(DriveService driveService, string folderName, string parentFolderId)
        {

            var result = await FindFolderAsync(driveService, folderName, parentFolderId);
            if (result != null) return result;
            var folderMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                Parents = parentFolderId != null ? new List<string> { parentFolderId } : null
            };

            var request = driveService.Files.Create(folderMetadata);
            var folder = await request.ExecuteAsync();
            return folder.Id;
        }

        private static async Task<string> FindFolderAsync(DriveService driveService, string folderName, string parentFolderId)
        {
            var listRequest = driveService.Files.List();
            listRequest.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folderName}'" + (parentFolderId != null ? $" and '{parentFolderId}' in parents" : "");

            var result = await listRequest.ExecuteAsync().ConfigureAwait(false);
            return result.Files.Count == 0 ? null : result.Files[0].Id;
        }

        private static async Task<string> FindParentFolder(DriveService driveService, string[] route = null)
        {
            string parentFolderId = null;

            if (route == null || route.Length <= 0) return parentFolderId;
            foreach (var folder in route)
            {
                parentFolderId = await FindFolderAsync(driveService, folder, parentFolderId).ConfigureAwait(false);
            }
            return parentFolderId;
        }

        private static async Task<string> UploadFileAsync(DriveService driveService, Stream fileStream, string mimeType, string name, string parentFolderId)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = name
            };

            FilesResource.ListRequest listRequest = driveService.Files.List();
            listRequest.Q = $"'{parentFolderId}' in parents and name='{name}'";
            var existingFiles = await listRequest.ExecuteAsync();

            if (existingFiles.Files.Count > 0)
            {
                var updateRequest = driveService.Files.Update(fileMetadata, existingFiles.Files[0].Id, fileStream, mimeType);
                updateRequest.AddParents = parentFolderId;
                var response = await updateRequest.UploadAsync();
                return existingFiles.Files[0].Id;
            }
            else
            {
                fileMetadata.Parents = new List<string> { parentFolderId };
                var createRequest = driveService.Files.Create(fileMetadata, fileStream, mimeType);
                var response = await createRequest.UploadAsync();
                return createRequest.ResponseBody.Id;
            }
        }

        public static async Task<string> CreatePublicUrlAsync(string fileId)
        {
            var driveService = InitializeDriveServiceAsync();

            var permission = new Google.Apis.Drive.v3.Data.Permission
            {
                Role = "reader",
                Type = "anyone"
            };

            await driveService.Permissions.Create(permission, fileId).ExecuteAsync();

            var fileRequest = driveService.Files.Get(fileId);
            fileRequest.Fields = "webViewLink, webContentLink";
            var file = await fileRequest.ExecuteAsync();

            return file.WebContentLink;
        }

        public static async Task<(Stream fileStream, string mimeType)> GetFileAsync(string fileName)
        {
            var driveService = InitializeDriveServiceAsync();
            var request = driveService.Files.List();
            request.Q = $"name contains '{fileName}'";
            request.Fields = "files(id, name, mimeType)";

            try
            {
                var result = await request.ExecuteAsync().ConfigureAwait(false);
                if (result.Files.Count == 0)
                {
                    throw new Exception("No se encontraron archivos con ese nombre.");
                }
                var file = result.Files[0];
                System.Diagnostics.Debug.WriteLine("el archivo que se va a buscar tiene id: " + file.Id);
                var getRequest = driveService.Files.Get(file.Id);
                var stream = new MemoryStream();
                await getRequest.DownloadAsync(stream).ConfigureAwait(false);
                stream.Position = 0;
                return (stream, file.MimeType);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<(String base64, string mimeType)> GetFileBase64Async(string fileName, string[] route = null)
        {

            if (fileName.Length <= 4)
            {
                return ("", "");
            }

            var driveService = InitializeDriveServiceAsync();
            string parentFolderId = await FindParentFolder(driveService, route).ConfigureAwait(false);

            var request = driveService.Files.List();
            request.Q = $"name = '{fileName}'" + (parentFolderId != null ? $" and '{parentFolderId}' in parents" : "");
            request.Fields = "files(id, name, mimeType)";

            try
            {
                var result = await request.ExecuteAsync().ConfigureAwait(false);
                if (result.Files.Count == 0)
                {
                    throw new Exception("No se encontraron archivos con ese nombre.");
                }
                var file = result.Files[0];
                var getRequest = driveService.Files.Get(file.Id);
                var stream = new MemoryStream();
                await getRequest.DownloadAsync(stream).ConfigureAwait(false);
                stream.Position = 0;
                return (Convert.ToBase64String(stream.ToArray()), file.MimeType);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<bool> DeleteFile(string fileName, string[] route = null)
        {
            var driveService = InitializeDriveServiceAsync();
            var parentFolderId = await FindParentFolder(driveService, route).ConfigureAwait(false);

            var request = driveService.Files.List();
            request.Q = $"name = '{fileName}'" + (parentFolderId != null ? $" and '{parentFolderId}' in parents" : "");
            request.Fields = "files(id, name, mimeType)";

            try
            {
                var result = await request.ExecuteAsync().ConfigureAwait(false);
                if (result.Files.Count == 0)
                {
                    return false;
                }
                var file = result.Files[0];
                var getRequest = driveService.Files.Delete(file.Id);
                await getRequest.ExecuteAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<string> FileExist(string fileName, string[] route = null)
        {
            var driveService = InitializeDriveServiceAsync();
            var parentFolderId = await FindParentFolder(driveService, route).ConfigureAwait(false);

            var request = driveService.Files.List();
            request.Q = $"name = '{fileName}'" + (parentFolderId != null ? $" and '{parentFolderId}' in parents" : "");
            request.Fields = "files(id, name, mimeType)";

            try
            {
                var result = await request.ExecuteAsync().ConfigureAwait(false);
                return result.Files.Count == 0 ? null : result.Files[0].Id;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<bool> RenameFileAsync(string fileId, string newName)
        {
            var driveService = InitializeDriveServiceAsync();

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = newName
            };

            try
            {
                var updateRequest = driveService.Files.Update(fileMetadata, fileId);
                await updateRequest.ExecuteAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error renombrando el archivo: {ex.Message}");
                return false;
            }
        }
    }
}