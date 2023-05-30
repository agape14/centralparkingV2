namespace ApiBD.Models.Home;

public class IndexVM
{
    public List<TbIndServiciocab> Servicios { get;  set; }
    public List<TbIndServiciodet> ServiciosDet { get;  set; }
    public List<TbIndSlidecab> SlideCad { get; set; }
    public List<TbIndCaracteristica> Valores { get;  set; }
    public TbConfPaginascab? PaginaCab { get; set; }
    public List<TbTraPuesto> Puestos { get;  set; }
}
