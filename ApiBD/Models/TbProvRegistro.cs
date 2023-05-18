using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbProvRegistro
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int? CodPersonaSolicita { get; set; }

    public int? CodPersonaInforFiscal { get; set; }

    public int? CodPersonaRepLegal { get; set; }

    public int? CodPersonaContactoComercial { get; set; }

    public int? AfectoRetencionIgv { get; set; }

    public int? AfectoDetraccionIgv { get; set; }

    public int? PorcentajeDetraccion { get; set; }

    public int? AfectoRenta4taCat { get; set; }

    public int? ExoneradoRenta4taCat { get; set; }

    public string ComprobanteExonera { get; set; }

    public int? TipoDocElectronicoRemite { get; set; }

    public int? TipoMonedaCompra { get; set; }

    public int? TiempoPago { get; set; }

    public string OtroTiempoPago { get; set; }

    public int? TipoPagoDinero { get; set; }

    public int? CodPersonaCobranza { get; set; }

    public int? CodBanco { get; set; }

    public string Titular { get; set; }

    public string NroCuenta { get; set; }

    public string Cci { get; set; }

    public virtual TbConfBanco CodBancoNavigation { get; set; }

    public virtual TbConfPersona CodPersonaCobranzaNavigation { get; set; }

    public virtual TbConfPersona CodPersonaContactoComercialNavigation { get; set; }

    public virtual TbConfPersona CodPersonaInforFiscalNavigation { get; set; }

    public virtual TbConfPersona CodPersonaRepLegalNavigation { get; set; }

    public virtual TbConfPersona CodPersonaSolicitaNavigation { get; set; }

    public virtual TbConfTimepago TiempoPagoNavigation { get; set; }

    public virtual TbConfDocelectronico TipoDocElectronicoRemiteNavigation { get; set; }

    public virtual TbConfMonedum TipoMonedaCompraNavigation { get; set; }

    public virtual TbConfTipopago TipoPagoDineroNavigation { get; set; }
}
