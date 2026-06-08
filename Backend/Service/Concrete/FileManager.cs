using Microsoft.AspNetCore.Http;
using Service.Abstract;

namespace Service.Concrete
{
    public class FileManager : IFileService
    {
        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                return null!;

            var extension = Path.GetExtension(file.FileName).ToLower();
            string typeFolder = "others";

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".webp" || extension == ".svg")
                typeFolder = "images";
            else if (extension == ".pdf")
            {
                if (folderName != null && folderName.ToLower().Contains("cv"))
                    typeFolder = "cv";
                else
                    typeFolder = "pdfs";
            }
            else if (extension == ".mp4" || extension == ".webm" || extension == ".avi" || extension == ".mov")
                typeFolder = "videos";
            else if (extension == ".doc" || extension == ".docx" || extension == ".xls" || extension == ".xlsx")
                typeFolder = "documents";

            var newFileName = Guid.NewGuid().ToString() + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", typeFolder);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var exactPath = Path.Combine(path, newFileName);

            using (var stream = new FileStream(exactPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{typeFolder}/{newFileName}";
        }

        public void DeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return;

            var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));

            if (File.Exists(exactPath))
            {
                File.Delete(exactPath);
            }
        }
    }
}
