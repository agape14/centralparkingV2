using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbIndServiciodet
{
    public int Id { get; set; }

    public int? IdCab { get; set; }

    public string Icono { get; set; }

    public string Titulo { get; set; }

    public string Detalle { get; set; }

    public string Ruta { get; set; }

    public string Imagen { get; set; }

    public virtual TbIndServiciocab IdCabNavigation { get; set; }
}
