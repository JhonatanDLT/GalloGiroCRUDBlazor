using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwInventario
{
    public int InventarioId { get; set; }

    public int Cantidad { get; set; }

    public int ProductoId { get; set; }

    public int Reorden { get; set; }

    public int EntidadId { get; set; }

    public string NombreEnt { get; set; } = null!;

    public int ZonaId { get; set; }

    public int TipoEntId { get; set; }

    public string NombreTipo { get; set; } = null!;
}
