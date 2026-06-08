using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file,string folderName);
        void DeleteFile(string filePath);
    }
}
