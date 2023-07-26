using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class TrasladosInventario
{
    public int TrasladoId { get; set; }

    public int OrigenId { get; set; }

    public int DestinoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public DateTime FechaTraslado { get; set; }

    public string? Razon { get; set; }

    public virtual Entidad Destino { get; set; } = null!;

    public virtual Entidad Origen { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
