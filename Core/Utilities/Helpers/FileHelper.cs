using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file != null)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            else if (file == null)
            {
                return null;
            }
            var result = createPath(file);
            File.Move(sourcepath, result);
            return result;
        }

        public static string createPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Environment.CurrentDirectory + @"\Images\carImages";
            var newPath = Guid.NewGuid().ToString()
                + "_" + DateTime.Now.Month
                + "_" + DateTime.Now.Day
                + "_" + DateTime.Now.Year
                + fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
