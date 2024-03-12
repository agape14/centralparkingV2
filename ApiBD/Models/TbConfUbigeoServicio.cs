namespace ApiBD.Models
{
    public class TbConfUbigeoServicio
    {
        public string CodUbi { get; set; }
        public int IdServicio { get; set; }

        public virtual TbConfUbigeo TbConfUbigeo { get; set; }
        public virtual TbServCabecera TbServCabecera { get; set; }
    }
}
