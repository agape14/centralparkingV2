using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormProveedore
{
    public DateTime Fecha { get; set; }

    public string SolicitadoPor { get; set; }

    public string FiscalRut { get; set; }

    public string FiscalDni { get; set; }

    public string FiscalNombre { get; set; }

    public string FiscalDireccion { get; set; }

    public string FiscalDistrito { get; set; }

    public string FiscalTelefono { get; set; }

    public string FiscalRubro { get; set; }

    public int? FiscalTipopersona { get; set; }

    public string FiscalCodigopostal { get; set; }

    public string FiscalFax { get; set; }

    public string ComercialNombre { get; set; }

    public string ComercialCargo { get; set; }

    public string ComercialCelular { get; set; }

    public string ComercialTelefono { get; set; }

    public string ComercialEmail { get; set; }

    public int? AfectoRetencionIgv { get; set; }

    public int? AfectoDetraccionIgv { get; set; }

    public int? PorcentajeDetraccion { get; set; }

    public int? AfectoRenta4taCat { get; set; }

    public int? ExoneradoRenta4taCat { get; set; }

    public string ComprobanteExonera { get; set; }

    public int? TipoDocElectronicoRemite { get; set; }

    public int? TipoMonedaCompra { get; set; }

    public int TiempoPago { get; set; }

    public string OtroTiempoPago { get; set; }

    public string ContactoCobranzaNombre { get; set; }

    public string ContactoCobranzaCargo { get; set; }

    public string ContactoCobranzaCelular { get; set; }

    public string ContactoCobranzaTelefono { get; set; }

    public string ContactoCobranzaEmail { get; set; }

    public int? CodBanco { get; set; }

    public string CuentaBancariaTitulo { get; set; }

    public string CuentaBancariaNumerocuenta { get; set; }

    public string Cci { get; set; }

    public virtual TbConfBanco CodBancoNavigation { get; set; }

    public virtual TbConfTimepago TiempoPagoNavigation { get; set; }

    public virtual TbConfDocelectronico TipoDocElectronicoRemiteNavigation { get; set; }

    public virtual TbConfMonedum TipoMonedaCompraNavigation { get; set; }
}
