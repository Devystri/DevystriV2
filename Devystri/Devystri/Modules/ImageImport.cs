using System;
using System.IO;
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
                if (el.ContentType.Contains("image"))
                {
                    using var image = Image.Load(el.OpenReadStream());
                    if(File.Exists(Path + el.FileName))
                    {
                        File.Delete(Path + el.FileName);
                    }
                    image.SaveAsPng(Path + el.FileName);
                }
                
            }
            return true;

        }

        public bool Delete(string name)
        {
            try
            {
                File.Delete(Path + name);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
