using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Inventario
{
    public int InventarioId { get; set; }

    public int EntidadId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public int Reorden { get; set; }

    public virtual Entidad Entidad { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
