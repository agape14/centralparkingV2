using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbIndSlidecab
{
    public uint Id { get; set; }

    public string? Titulo { get; set; }

    public string? Imagen { get; set; }

    public int? IdBtn1 { get; set; }

    public virtual TbConfBotone? IdBtn1Navigation { get; set; }
}