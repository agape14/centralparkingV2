using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbServFormulario
{
    public int Id { get; set; }

    public int? IdServicio { get; set; }

    public string CodUbigeo { get; set; }

    public int? IdEstacionamiento { get; set; }

    public string Ruc { get; set; }

    public string RazonSocial { get; set; }

    public string ApellidosNombres { get; set; }

    public string Celular { get; set; }

    public string Telefono { get; set; }

    public string Correo { get; set; }

    public virtual TbServCabecera IdServicioNavigation { get; set; }
}
