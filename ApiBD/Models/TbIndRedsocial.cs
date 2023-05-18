using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbIndRedsocial
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Clasehead { get; set; }

    public string Ruta { get; set; }

    public string Clasefoot { get; set; }

    public string Icono { get; set; }

    public string Color { get; set; }

    public int? Estado { get; set; }
}
