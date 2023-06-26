using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormParkingcard
{
    public int Id { get; set; }

    /// <summary>
    /// dni del usuario
    /// </summary>
    public string Dni { get; set; }

    /// <summary>
    /// correo del usuario
    /// </summary>
    public string Correo { get; set; }

    /// <summary>
    /// codigo de seguridad aleatorio que genera el sistema de 20 caracteres
    /// </summary>
    public string CodSeguridad { get; set; }

    /// <summary>
    /// fecha actual de registro
    /// </summary>
    public DateTime? FecRegistro { get; set; }

    /// <summary>
    /// valida si esta notificacion fue verificado
    /// </summary>
    public int? Notificado { get; set; }
}
