using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormTbcnosotro
{
    public int Id { get; set; }

    public int? TipoDocumento { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string CorreoElectronico { get; set; }

    public string Departamento { get; set; }

    public string Provincia { get; set; }

    public int? Distrito { get; set; }

    public string Puesto { get; set; }

    public string InformacionAdicional { get; set; }

    public string NumeroDocumento { get; set; }

    public string Celular { get; set; }

    public string Medio { get; set; }
}
