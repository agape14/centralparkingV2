using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbTraPuesto
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Subtitulo { get; set; }

    public string Requisitos { get; set; }

    public string Ruta { get; set; }

    /// <summary>
    /// 0: Sin ocupar; 1: ocupado
    /// </summary>
    public int? Ocupado { get; set; }
}
