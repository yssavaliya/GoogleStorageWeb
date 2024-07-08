//using System.IO;
//using System.IO.Compression;
//using System.Text.Json;
//using Google.Apis.Drive.v3.Data;
//using UploadDrive;

//string folderId = "1-UoTEkucEmjpVkIv0PD05HWTxkzlHZw7";
//string fileUploadPath = "C:\\Users\\YASH\\OneDrive\\Desktop\\Research\\DriveTXT\\DriveTXT\\upload\\File.txt";

//uplload
//Extend.UploadFileToGoogleDrive(folderId, fileUploadPath);

//get list file
//Console.WriteLine("====");
//var listFile = Extend.GetLisFiles(folderId);
//foreach (var file in listFile)
//{
//    Console.WriteLine($"{file.Name} {file.Id}");
//}

//delete
//var fileId = "14AmpYVy1GpprKXVVZ3zXxpJ3vDrHzzZZ";
//Extend.DeleteFile(fileId);





//string folderId = "1-UoTEkucEmjpVkIv0PD05HWTxkzlHZw7";
//string filePath = "C:\\Users\\YASH\\OneDrive\\Desktop\\Research\\DriveTXT\\DriveTXT\\upload\\File.txt";


//string message = Extend.UploadFileToGoogleDrive(folderId, filePath);
//Console.WriteLine(message);


//string fileId = "file-id-to-delete";
//Extend.DeleteFile(fileId);

//string fileName = "example3";
//string fileContent = "This is a test content for the file.";
//string fileExtension = "txt"; // Optional, default is "txt"

//string message = Extend.CreateAndUploadFile(folderId, fileName, fileContent, fileExtension);
//Console.WriteLine(message);



//var files = Extend.GetListFiles(folderId);
//foreach (var file in files)
//{
//    // Console.WriteLine($"File ID: {file.Id}, Name: {file.Name}, Size: {file.Size} bytes, MimeType: {file.MimeType}, Created Time: {file.CreatedTime}");
//    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
//    Console.WriteLine("| File ID              | Name                         | Size (bytes) | MimeType              | Created Time        |");
//    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
//    Console.WriteLine($"| {file.Id,-20} | {file.Name,-30} | {file.Size,-12} | {file.MimeType,-22} | {file.CreatedTime,-20} |");
//    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");

//}
