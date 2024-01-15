namespace ApiBD.Models.Home;

public class IndexVM
{
    public List<TbIndServiciocab> Servicios { get;  set; }
    public List<TbIndServiciodet> ServiciosDet { get;  set; }
    public List<TbIndSlidecab> SlideCad { get; set; }
    public List<TbIndCaracteristica> Valores { get;  set; }
    public TbConfPaginascab? PaginaCab { get; set; }
    public List<TbTraPuesto> Puestos { get;  set; }

    public TbConfModalcab ModalCabs2 { get; set; }
    public List<TbConfModaldet> ListModalDet6 { get; set; }

    public TbConfModalcab ModalCabs5 { get; set; }
    public List<TbConfModaldet> ListModalDet9 { get; set; }

    public TbConfModalcab ModalCabs7 { get; set; }
    public List<TbConfModaldet> ListModalDet12 { get; set; }
    public TbConfModalcab ModalCabs8 { get; set; }
    public List<TbConfModaldet> ListModalDet13 { get; set; }
    public TbConfModalcab ModalCabs9 { get; set; }
    public List<TbConfModaldet> ListModalDet14 { get; set; }
    public TbConfModalcab ModalCabs10 { get; set; }
    public List<TbConfModaldet> ListModalDet15 { get; set; }
    public TbFormProveedore Proveedor { get; set; }
}
