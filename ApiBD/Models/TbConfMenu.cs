using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfMenu
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Ruta { get; set; }

    public int? Idtipomenu { get; set; }

    public int? Acceso { get; set; }

    public int? Padre { get; set; }

    public int? Estado { get; set; }
    public string TipoProyecto { get; set; }
    public string Icono { get; set; }

    public virtual TbConfTipomenu IdtipomenuNavigation { get; set; }

    public virtual ICollection<TbConfPermiso> TbConfPermisos { get; set; } = new List<TbConfPermiso>();
   
}
