using ApiBD.Models;

namespace CentralParkingSystem.DTOs
{
    public class Slides
    {

        public uint Id { get; set; }

        public string Titulo { get; set; }

        public string Imagen { get; set; }

        public int IdBtn1 { get; set; }

        public  TbConfBotone IdBtn1Navigation { get; set; }
    }
}
