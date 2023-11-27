using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}//ProductPictures//{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
        public OperationResult DeleteFile(string path)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeleteFolder(string path)
        {
            OperationResult operation = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                    return operation.Failed(ApplicationMessages.RecordNotFound);
                var directoryPath = path.Replace("//", "/");
                string[] subs = directoryPath.Split('/');
                directoryPath = subs[0] + "/" + subs[1];
                directoryPath = $"{_webHostEnvironment.WebRootPath}//ProductPictures//{directoryPath}";

                if (!Directory.Exists(directoryPath))
                    return operation.Failed(ApplicationMessages.RecordNotFound);
                Directory.Delete(directoryPath, true);
                return operation.Succedded();
            }
            catch (Exception e)
            {
                return operation.Failed("Error");
            }
        }

    }
}
