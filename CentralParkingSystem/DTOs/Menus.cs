using ApiBD.Models;

namespace CentralParkingSystem.DTOs
{
    public class Menus
    {
        //public int Id { get; set; }

        //public string Nombre { get; set; }

        //public string Ruta { get; set; }

        //public int Idtipomenu { get; set; }

        //public int Acceso { get; set; }

        //public int Padre { get; set; }

        //public int Estado { get; set; }

        //public  TbConfTipomenu IdtipomenuNavigation { get; set; }

        //public  ICollection<TbConfPermiso> TbConfPermisos { get; set; } = new List<TbConfPermiso>();



        public List<Result> Result { get; set; }
        public int Id { get; set; }
        public object Exception { get; set; }
        public int Status { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCompletedSuccessfully { get; set; }
        public int CreationOptions { get; set; }
        public object AsyncState { get; set; }
        public bool IsFaulted { get; set; }



    }
}


