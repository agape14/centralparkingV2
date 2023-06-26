using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfModalcab
{
    public int Id { get; set; }

    public int? IdDetallePie { get; set; }

    public string Titulo { get; set; }

    public string BtnRuta { get; set; }

    public int? Estado { get; set; }
}
