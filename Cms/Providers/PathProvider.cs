using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Cms.Providers
{
    public enum Folders
    {
        Uploads = 0, Images = 1, Documents = 2, Temp = 3
    }

    public class PathProvider
    {
        private IWebHostEnvironment hostEnvironment;
        public PathProvider(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";

            if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Documents)
            {
                carpeta = "docs";
            }

            string path = Path.Combine(this.hostEnvironment.WebRootPath, carpeta, fileName);
           if (folder == Folders.Temp)
            {
                path = Path.Combine(Path.GetTempPath(), fileName);
            }

            return path;
        }

        public string MapPathWeb(string fileName, Folders folder)
        {
            string carpeta = "";

            if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Documents)
            {
                carpeta = "docs";
            }

            //string path = Path.Combine(this.hostEnvironment.WebRootPath, carpeta, fileName);
            string destinationWeb = Path.Combine(this.hostEnvironment.ContentRootPath, "CentralParkingSystem", carpeta, fileName);
            if (folder == Folders.Temp)
            {
                destinationWeb = Path.Combine(Path.GetTempPath(), fileName);
            }

            return destinationWeb;
        }
    }
}
