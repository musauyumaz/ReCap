using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class ImageFileHelper
    {
        private static string root = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root;
        private static string defaultCarImage = "default.png";
        public static string Upload(IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                string fileName = Path.GetFileName(formFile.FileName);
                string guid = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(fileName);
                string newFileName = guid + fileExtension;
                string filePath = root + $@"\{newFileName}";

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                return filePath.Replace("\\", "/");
                //return filePath;
            }
            return "";
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
        }


        public static string GetDefaultCarImagePath()
        {
            return root + defaultCarImage;
        }
    }
}
