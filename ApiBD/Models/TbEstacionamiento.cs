namespace ApiBD.Models
{
    public class TbEstacionamiento
    {
        public int Id { get; set; }
        public string? CodUbi { get; set; }
        public string? Estacionamiento { get; set; }

        public virtual TbConfUbigeo TbConfUbigeo { get; set; }
    }
}
