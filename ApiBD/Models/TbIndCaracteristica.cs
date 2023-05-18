using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbIndCaracteristica
{
    public uint Id { get; set; }

    public string Titulo { get; set; }

    public string Icono { get; set; }

    public string Detalle { get; set; }
}
