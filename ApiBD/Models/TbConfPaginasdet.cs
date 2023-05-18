using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfPaginasdet
{
    public int Id { get; set; }

    public int? PaginaId { get; set; }

    public string Titulo { get; set; }

    public string Detalle { get; set; }

    public string Imagen { get; set; }
}
