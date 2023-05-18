using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfPermiso
{
    public int Id { get; set; }

    public string Permiso { get; set; }

    public string Descripcion { get; set; }

    public int? MenuId { get; set; }

    public int? RolId { get; set; }

    public int? Estado { get; set; }

    public DateTime? Creacion { get; set; }

    public DateTime? Modificacion { get; set; }

    public virtual TbConfMenu Menu { get; set; }

    public virtual TbConfRole Rol { get; set; }
}
