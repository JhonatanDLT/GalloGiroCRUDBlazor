using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Entrega
{
    public int EntregaId { get; set; }

    public string MetodoEntrega { get; set; } = null!;

    public string? DescripcionEntrega { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
