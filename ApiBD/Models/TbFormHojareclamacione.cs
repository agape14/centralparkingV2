using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbFormHojareclamacione
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? Fechaindicente { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Correo { get; set; }

    public string Telefono { get; set; }

    public string Tipodocumento { get; set; }

    public string Numerodocumento { get; set; }

    public sbyte? Menordeedad { get; set; }

    public string Departamento { get; set; }

    public string Provincia { get; set; }

    public string Distrito { get; set; }

    public string Direccion { get; set; }

    public string Reclamo { get; set; }

    public string Tiposervicio { get; set; }

    public string Estacionamiento { get; set; }

    public string Detalle { get; set; }
}
