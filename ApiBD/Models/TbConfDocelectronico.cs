using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfDocelectronico
{
    public int Id { get; set; }

    public string DocumentoElectronico { get; set; }

    public virtual ICollection<TbProvRegistro> TbProvRegistros { get; set; } = new List<TbProvRegistro>();
}
