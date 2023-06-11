using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormContactano
{
    public int Id { get; set; }

    public int? TipoServicio { get; set; }

    public string Nombre { get; set; }

    public string Asunto { get; set; }

    public string Mensaje { get; set; }

    public string CorreoElectronico { get; set; }

    public virtual TbIndServiciodet TipoServicioNavigation { get; set; }
}
