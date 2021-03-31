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
                if (el.ContentType.Contains("image"))
                {
                    if (el.ContentType.Contains("svg"))
                    {
                        using (var streamReader = new MemoryStream())
                        {
                            el.OpenReadStream().CopyTo(streamReader);
                            using (FileStream fs = File.Create(Path + el.FileName))
                            {
                                fs.Write(streamReader.ToArray(), 0, streamReader.ToArray().Length);
                               
                            }
                        }
                    }
                    else
                    {
                        using var image = Image.Load(el.OpenReadStream());
                        if (File.Exists(Path + el.FileName))
                        {
                            File.Delete(Path + el.FileName);
                        }
                        image.SaveAsPng(Path + el.FileName);
                    }
                 
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
