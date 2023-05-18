using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfTipopago
{
    public int Id { get; set; }

    public string TipoPago { get; set; }

    public virtual ICollection<TbProvRegistro> TbProvRegistros { get; set; } = new List<TbProvRegistro>();
}
