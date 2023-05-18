using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbServDetalle
{
    public int Id { get; set; }

    public int IdServicio { get; set; }

    public string Subtitulo { get; set; }

    public string Descripcion { get; set; }

    public int? IdBtnSolicitalo { get; set; }

    public virtual TbConfBotone IdBtnSolicitaloNavigation { get; set; }

    public virtual TbServCabecera IdServicioNavigation { get; set; }
}
