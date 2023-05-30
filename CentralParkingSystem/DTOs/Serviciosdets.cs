using ApiBD.Models;

namespace CentralParkingSystem.DTOs
{
    public class Serviciosdets
    {
        public int Id { get; set; }

        public int IdCab { get; set; }

        public string? Icono { get; set; }

        public string? Titulo { get; set; }

        public string? Detalle { get; set; }

        public string? Ruta { get; set; }

        public string? Imagen { get; set; }

        public  TbIndServiciocab? IdCabNavigation { get; set; }
    }
}
