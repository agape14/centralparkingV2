using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfPaginascab
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Subtitulo { get; set; }

    public string ReseniaTitulo { get; set; }

    public string ReseniaDetalle { get; set; }

    public string MisionTitulo { get; set; }

    public string MisionDetalle { get; set; }

    public string VisionTitulo { get; set; }

    public string VisionDetalle { get; set; }

    public string ValoresTitulo { get; set; }

    public string ValoresDetalle { get; set; }

    public string ReconocTitulo { get; set; }

    public string ReconocDetalle { get; set; }

    public string ImagenMision { get; set; }

    public string ImagenValores { get; set; }
}
