using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;

namespace Devystri.Modules
{
    public class ImageImport
    {
     
        public string Path { get; set; }

        public ImageImport(string path)
        {
            Path = path;
        }

        public bool Import(IFormFileCollection collection)
        {
            foreach (var el in collection)
            {
                if (el.Length > 0 && CorrectFileExtension(el.FileName))
                {
                    string filePath = Path + el.FileName;
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
            var extentions = new string[] { "png", "jpeg", "svg", "glb" };
            foreach (var extention in extentions)
            {
                if (filename.Contains(extention))
                    return true;
                
            }
            return false;
        }
        public bool Delete(string name)
        {
            try
            {
                File.Delete(Path + name);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
