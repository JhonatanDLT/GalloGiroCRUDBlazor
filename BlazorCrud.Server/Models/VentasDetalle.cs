using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VentasDetalle
{
    public int Folio { get; set; }

    public int ProductoId { get; set; }

    public decimal? Precioventa { get; set; }

    public int Cantidad { get; set; }

    public float Descuento { get; set; }

    public virtual Venta FolioNavigation { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
