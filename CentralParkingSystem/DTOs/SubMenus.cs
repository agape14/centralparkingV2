namespace CentralParkingSystem.DTOs
{
    public class SubMenus
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ruta { get; set; }
        public int IdTipomenu { get; set; }
        public int Acceso { get; set; }
        public int Padre { get; set; }
        public int Estado { get; set; }
        public string? TipoProyecto { get; set; }
        public string? Icono { get; set; }

        public object? IdTipomenuNavigation { get; set; }
        public List<object>? TbConfPermisos { get; set; }

    }
}
