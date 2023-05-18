﻿using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfBanco
{
    public int Id { get; set; }

    public string Banco { get; set; }

    public virtual ICollection<TbProvRegistro> TbProvRegistros { get; set; } = new List<TbProvRegistro>();
}
