using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.FileService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {

        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtentions)
        {
           
            
                if (imageFile == null)
                {
                    throw new ArgumentNullException(nameof(imageFile));
                }
                var contentPath = _environment.ContentRootPath;
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var extension = Path.GetExtension(imageFile.FileName);
                if (!allowedFileExtentions.Contains(extension))
                {
                    throw new ArgumentException($"Only{string.Join(",", allowedFileExtentions)} are allowed");
                }

                var fileName = $"{Guid.NewGuid().ToString()}{extension}";
                var fileNameWithPath = Path.Combine(path, fileName);

                using var stream = new FileStream(fileNameWithPath, FileMode.Create);

                await imageFile.CopyToAsync(stream);
                return $"/Uploads/{fileName}";

            

        }
    }
}
