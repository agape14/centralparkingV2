namespace CentralParkingSystem.DTOs
{
    public class Result
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ruta { get; set; }
        public int Idtipomenu { get; set; }
        public int Acceso { get; set; }
        public int Padre { get; set; }
        public int Estado { get; set; }
        public object? IdtipomenuNavigation { get; set; }
        public List<object>? TbConfPermisos { get; set; }
    }
}
