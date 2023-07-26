using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwZonasMun
{
    public int ZonasMunId { get; set; }

    public int ZonaId { get; set; }

    public string NombreZona { get; set; } = null!;

    public string? DescripcionZona { get; set; }

    public int MunId { get; set; }

    public string NombreMun { get; set; } = null!;
}
