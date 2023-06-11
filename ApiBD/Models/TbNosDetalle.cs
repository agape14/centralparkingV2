using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbNosDetalle
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Detalle { get; set; }

    public int? Espacio { get; set; }

    public string Imagen { get; set; }

    public string Icono { get; set; }
}
