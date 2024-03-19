using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfUbigeo
{
    public string CodUbi { get; set; }

    public string Dpto { get; set; }

    public string Prov { get; set; }

    public string Dist { get; set; }
    public virtual ICollection<TbConfUbigeoServicio> TbConfUbigeoServicios { get; set; } = new List<TbConfUbigeoServicio>();
    public virtual ICollection<TbEstacionamiento> TbPlayasEstacionamientos { get; set; } = new List<TbEstacionamiento>();
}
