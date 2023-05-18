using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfRole
{
    public int Id { get; set; }

    public string Rol { get; set; }

    public string Descripcion { get; set; }

    public int? PermisoId { get; set; }

    public int? Estado { get; set; }

    public DateTime? Creacion { get; set; }

    public DateTime? Modificacion { get; set; }

    public virtual ICollection<TbConfPermiso> TbConfPermisos { get; set; } = new List<TbConfPermiso>();

    public virtual ICollection<TbConfUser> TbConfUsers { get; set; } = new List<TbConfUser>();
}
