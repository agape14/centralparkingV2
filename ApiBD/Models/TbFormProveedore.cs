using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormProveedore
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string SolicitadoPor { get; set; }

    public string FRuc { get; set; }

    public string FDni { get; set; }

    public string FNombre { get; set; }

    public string FDireccion { get; set; }

    public string FDistrito { get; set; }

    public string FTelefono { get; set; }

    public string FRubro { get; set; }

    public int? FTipoPersona { get; set; }

    public string FCodigoPostal { get; set; }

    public string FFax { get; set; }

    public string RlNombre { get; set; }

    public string RlCargo { get; set; }

    public string RlCelular { get; set; }

    public string RlTelefono { get; set; }

    public string RlEmail { get; set; }

    public string CcNombre { get; set; }

    public string CcCargo { get; set; }

    public string CcCelular { get; set; }

    public string CcTelefono { get; set; }

    public string CcEmail { get; set; }

    public bool? AfectoRetencionDeIgv { get; set; }

    public bool? AfectoDetraccionDeIgv { get; set; }

    public double? PorcentajeDetraccion { get; set; }

    public bool? AfectoRentade4taCategoría { get; set; }

    public bool? Exoneradorenta4ta { get; set; }

    public string ComprobanteExoneracion { get; set; }

    public bool? TipoDocumentoFactura { get; set; }

    public bool? TipoDocumentoReciboHonorarios { get; set; }

    public bool? TipoDocumentoOtros { get; set; }

    public bool? DatosCompraSoles { get; set; }

    public bool? DatosCompraDolares { get; set; }

    public bool? DatosCompraAmbas { get; set; }

    public bool? InformacionPagoProveedor30dias { get; set; }

    public bool? InformacionPagoProveedor60dias { get; set; }

    public bool? InformacionPagoProveedorEfectivo { get; set; }

    public bool? InformacionPagoProveedorTranferenciaBancaria { get; set; }

    public string InformacionPagoProveedorOtros { get; set; }

    public string CcobranzaNombre { get; set; }

    public string CcobranzaCargo { get; set; }

    public string CcobranzaCelular { get; set; }

    public string CcobranzaTelefono { get; set; }

    public string CcobranzaEmail { get; set; }

    public int? CodCuentaBancaria { get; set; }

    public string CuentaBancaria { get; set; }

    public string CuentaBancariaTitular { get; set; }

    public string CuentaBancariaCci { get; set; }

    public virtual TbConfBanco CodCuentaBancariaNavigation { get; set; }
}
