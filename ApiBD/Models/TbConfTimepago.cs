using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfTimepago
{
    public int Id { get; set; }

    public string TimePago { get; set; }

    public virtual ICollection<TbProvRegistro> TbProvRegistros { get; set; } = new List<TbProvRegistro>();
}
