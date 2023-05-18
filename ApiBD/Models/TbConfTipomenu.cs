using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfTipomenu
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public string Opcion { get; set; }

    public virtual ICollection<TbConfMenu> TbConfMenus { get; set; } = new List<TbConfMenu>();
}
