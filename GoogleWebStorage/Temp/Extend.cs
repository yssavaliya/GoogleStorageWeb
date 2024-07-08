//using Google;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;
//using Google.Apis.Upload;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace UploadDrive
//{
//    public class Extend
//    {
//        public static string UploadFileToGoogleDrive(string folderId, string filePath)
//        {
//            string mess = "";
//            var service = GetService();

//            var fileMetaData = new Google.Apis.Drive.v3.Data.File()
//            {
//                Name = Path.GetFileName(filePath),
//                Parents = new List<string> { folderId },
//            };

//            // Upload file
//            FilesResource.CreateMediaUpload request;
//            using (var stream = new FileStream(filePath, FileMode.Open))
//            {
//                request = service.Files.Create(fileMetaData, stream, "");
//                request.Fields = "id";
//                var response = request.Upload();
//                if (response.Status != UploadStatus.Completed)
//                {
//                    mess = $"Error uploading file: {response.Exception.Message}";
//                }
//                else
//                {
//                    var uploadedFile = request.ResponseBody;
//                    mess = $"File {fileMetaData.Name} successfully uploaded ({response.BytesSent / 1024} KB) to Drive. File ID: {uploadedFile.Id}";
//                }
//            }
//            return mess;
//        }

//        public static DriveService GetService()
//        {
//            string credentialPath = "C:\\Users\\YASH\\OneDrive\\Desktop\\Research\\DriveTXT\\DriveTXT\\fileuploadandcreate-1e566e7b3395.json";
//            GoogleCredential credential;
//            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
//            {
//                credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
//                {
//                    DriveService.ScopeConstants.DriveFile
//                });
//            }

//            var service = new DriveService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = "Google Drive Upload Console App"
//            });

//            return service;
//        }

//        public static void DeleteFile(string fileId)
//        {
//            var service = GetService();

//            try
//            {
//                var request = service.Files.Delete(fileId);
//                string result = request.Execute(); // Send the delete request

//                // Check if the deletion was successful
//                if (string.IsNullOrEmpty(result))
//                {
//                    Console.WriteLine("File deleted successfully!");
//                }
//                else
//                {
//                    Console.WriteLine("Error deleting file: " + result);
//                }
//            }
//            catch (GoogleApiException e)
//            {
//                Console.WriteLine("Error deleting file: " + e.Message);
//            }
//        }

//        public static string CreateAndUploadFile(string folderId, string fileName, string fileContent, string fileExtension = "txt")
//        {
//            // Create a temporary file
//            string tempFilePath = Path.Combine("C:\\Users\\YASH\\OneDrive\\Desktop\\Research\\DriveTXT\\DriveTXT\\Temp\\", $"{fileName}.{fileExtension}");
//            File.WriteAllText(tempFilePath, fileContent);

//            // Upload the file to Google Drive
//            string resultMessage = UploadFileToGoogleDrive(folderId, tempFilePath);

//            // Delete the temporary file
//            File.Delete(tempFilePath);

//            return resultMessage;
//        }


//        public static IEnumerable<Google.Apis.Drive.v3.Data.File> GetListFiles(string folder)
//        {
//            var service = GetService();

//            var fileList = service.Files.List();
//            fileList.Q = $"mimeType!='application/vnd.google-apps.folder' and '{folder}' in parents";
//            fileList.Fields = "nextPageToken, files(id, name, size, mimeType, createdTime)";

//            var result = new List<Google.Apis.Drive.v3.Data.File>();
//            string pageToken = null;
//            do
//            {
//                fileList.PageToken = pageToken;
//                var filesResult = fileList.Execute();
//                var files = filesResult.Files;
//                pageToken = filesResult.NextPageToken;
//                result.AddRange(files);
//            } while (pageToken != null);

//            return result;
//        }
//    }
//}
