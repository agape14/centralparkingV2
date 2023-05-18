using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfPiepaginadet
{
    public int Id { get; set; }

    public int? PiepaginaId { get; set; }

    public string Icono { get; set; }

    public string Titulo { get; set; }

    public string Ruta { get; set; }

    public string Imagen { get; set; }

    /// <summary>
    /// 1: Link nueva pestaña; 2: Modal
    /// </summary>
    public int? TipoRuta { get; set; }
}
