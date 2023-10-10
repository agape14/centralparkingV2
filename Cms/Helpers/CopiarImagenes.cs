using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Cms.Helpers
{
    public class CopiarImagenes
    {
        private IWebHostEnvironment hostEnvironment;
        public CopiarImagenes(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public bool enviaimagen()
        {
            try
            {
                string rutaBat = Path.Combine(this.hostEnvironment.WebRootPath, "bachero", "copiaimagenes.bat");
                if (File.Exists(rutaBat))
                {
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = rutaBat;
                    proceso.StartInfo.UseShellExecute = false; // No use la shell del sistema
                    proceso.StartInfo.RedirectStandardOutput = true; // Captura la salida estándar (si es necesario)
                    proceso.StartInfo.RedirectStandardError = true; // Captura la salida de errores (si es necesario)
                    proceso.Start();
                    Thread.Sleep(2000);
                    // Puedes leer la salida estándar y la salida de errores si es necesario
                    string output = proceso.StandardOutput.ReadToEnd();
                    string error = proceso.StandardError.ReadToEnd();
                    proceso.Kill();

                    if (proceso.ExitCode == 0)
                    {
                        Console.WriteLine("Copia de imágenes completada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine($"Error al copiar imágenes: {error}");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("El archivo copiaimagenes.bat no existe en la ubicación especificada.");
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            return true;
        }
    }
}
