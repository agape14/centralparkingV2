using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbIndServiciocab
{
    public int Id { get; set; }

    public string TituloGrande { get; set; }

    public string TituloPeque { get; set; }

    public string Descripcion { get; set; }

    public string ImagenGrande { get; set; }

    public string ImagenPeque { get; set; }

    public string Ruta { get; set; }

    public virtual ICollection<TbIndServiciodet> TbIndServiciodets { get; set; } = new List<TbIndServiciodet>();
}
