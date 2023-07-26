using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwEntidad
{
    public int EntidadId { get; set; }

    public string NombreEnt { get; set; } = null!;

    public int ZonaId { get; set; }

    public string NombreZona { get; set; } = null!;

    public string? DescripcionZona { get; set; }

    public int TipoEntId { get; set; }

    public string NombreTipo { get; set; } = null!;
}
