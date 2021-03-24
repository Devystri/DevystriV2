using System;
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
                    image.SaveAsPng(Path + el.FileName);
                }
                
            }
            return true;

        }
    

    }
}
