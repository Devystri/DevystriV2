using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;

namespace Devystri.Modules
{
    public class ImageImport
    {
     
        public string PathString { get; set; }

        public ImageImport(string path)
        {

            PathString = Path.Combine(
                  Directory.GetCurrentDirectory(), path);
        }

        public bool Import(IFormFileCollection collection)
        {
            foreach (var el in collection)
            {
                if (el.Length > 0 && CorrectFileExtension(el.FileName.Replace(" ", string.Empty)))
                {
                    string fileName = el.FileName.Replace(" ", string.Empty);
                    string filePath = Path.Combine(PathString, fileName);
                    if (File.Exists(filePath))
                    {
                        Delete(filePath);
                    }
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        el.CopyTo(fileStream);
                    }
                }
            }
            return true;

        }
        private static bool CorrectFileExtension(string filename)
        {
            var extentions = new string[] { "png", "jpeg", "svg", "glb", "jpg" };
            foreach (var extention in extentions)
            {
                if (filename.ToLower().Contains(extention))
                    return true;
                
            }
            return false;
        }
        public bool Delete(string path)
        {
            try
            {
                File.Delete(path.Replace(" ", string.Empty));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
