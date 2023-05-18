using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfBotone
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public int? PaginadetId { get; set; }

    public string BtnTitulo { get; set; }

    public string BtnRuta { get; set; }

    public string BtnClase { get; set; }

    public string Icono { get; set; }

    public int? Orden { get; set; }

    public virtual ICollection<TbIndSlidecab> TbIndSlidecabs { get; set; } = new List<TbIndSlidecab>();

    public virtual ICollection<TbServCabecera> TbServCabeceraIdBtnConoceNavigations { get; set; } = new List<TbServCabecera>();

    public virtual ICollection<TbServCabecera> TbServCabeceraIdBtnSolicitarNavigations { get; set; } = new List<TbServCabecera>();

    public virtual ICollection<TbServDetalle> TbServDetalles { get; set; } = new List<TbServDetalle>();
}
