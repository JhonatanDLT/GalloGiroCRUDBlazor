using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class ComprasDetalle
{
    public int Folio { get; set; }

    public int ProductId { get; set; }

    public decimal Preciocompra { get; set; }

    public int Cantidad { get; set; }

    public virtual Compra FolioNavigation { get; set; } = null!;

    public virtual Producto Product { get; set; } = null!;
}
