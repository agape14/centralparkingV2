using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfModaldet
{
    public int Id { get; set; }

    public int? ModalcabId { get; set; }

    public string Titulo { get; set; }

    public string Descripcion { get; set; }
}
