using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfPersona
{
    public int Id { get; set; }

    /// <summary>
    /// N: Natural, J:Juridica
    /// </summary>
    public string TipoPersona { get; set; }

    /// <summary>
    /// 1:Solicitante,2:InforFiscal,3:RepresLegal,4:ContactoComer,5:Cobranza
    /// </summary>
    public int? TipoRegistro { get; set; }

    public string Ruc { get; set; }

    public string Dni { get; set; }

    public string Nombres { get; set; }

    public string ApPaterno { get; set; }

    public string ApMaterno { get; set; }

    public string RazonSocial { get; set; }

    public string Direccion { get; set; }

    public string CodDistrito { get; set; }

    public string CodPostal { get; set; }

    public string Telefono { get; set; }

    public string Fax { get; set; }

    public int? CodRubro { get; set; }

    public string Celular { get; set; }

    public string Correo { get; set; }

    public string Cargo { get; set; }

    public virtual ICollection<TbProvRegistro> TbProvRegistroCodPersonaCobranzaNavigations { get; set; } = new List<TbProvRegistro>();

    public virtual ICollection<TbProvRegistro> TbProvRegistroCodPersonaContactoComercialNavigations { get; set; } = new List<TbProvRegistro>();

    public virtual ICollection<TbProvRegistro> TbProvRegistroCodPersonaInforFiscalNavigations { get; set; } = new List<TbProvRegistro>();

    public virtual ICollection<TbProvRegistro> TbProvRegistroCodPersonaRepLegalNavigations { get; set; } = new List<TbProvRegistro>();

    public virtual ICollection<TbProvRegistro> TbProvRegistroCodPersonaSolicitaNavigations { get; set; } = new List<TbProvRegistro>();
}
