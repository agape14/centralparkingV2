using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormCotizano
{
    public int Id { get; set; }

    public int? TipoServicio { get; set; }

    public string Distrito { get; set; }

    public string Direccion { get; set; }

    public string Ruc { get; set; }

    public string RazonSocial { get; set; }

    public string Contacto { get; set; }

    public string Celular { get; set; }

    public string Telefono { get; set; }

    public DateTime? FechaEvento { get; set; }
    public string CorreoElectronico { get; set; }
    public string Comentario { get; set; }

    public virtual TbIndServiciodet TipoServicioNavigation { get; set; }
}
