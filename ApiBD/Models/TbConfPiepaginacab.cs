using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfPiepaginacab
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Imagen { get; set; }

    public int? Orden { get; set; }

    public int? Estado { get; set; }
}
