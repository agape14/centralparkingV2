using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbServCabecera
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string DescCorto { get; set; }

    public int? IdBtnSolicitar { get; set; }

    public int? IdBtnConoce { get; set; }

    public string Imagen { get; set; }

    /// <summary>
    /// true:Esta en el menu, false: No esta en el menu
    /// </summary>
    public byte[] IsMenu { get; set; }

    public virtual TbConfBotone IdBtnConoceNavigation { get; set; }

    public virtual TbConfBotone IdBtnSolicitarNavigation { get; set; }

    public virtual ICollection<TbServDetalle> TbServDetalles { get; set; } = new List<TbServDetalle>();

    public virtual ICollection<TbServFormulario> TbServFormularios { get; set; } = new List<TbServFormulario>();
}
