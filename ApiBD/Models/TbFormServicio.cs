using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormServicio
{
    public int Id { get; set; }

    public int? TipoServicio { get; set; }

    public string Distrito { get; set; }

    public string DireccionEstacionamiento { get; set; }

    public string Ruc { get; set; }

    public string RazonSocial { get; set; }

    public string DatosContacto { get; set; }

    public string Celular { get; set; }

    public string Telefono { get; set; }

    public string CorreoElectronico { get; set; }

    public virtual TbIndServiciodet TipoServicioNavigation { get; set; }
}
