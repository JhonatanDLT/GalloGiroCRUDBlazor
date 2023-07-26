using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class CreditoCli
{
    public int CreditoId { get; set; }

    public int ClienteId { get; set; }

    public decimal MontoTotal { get; set; }

    public DateTime FechaCompra { get; set; }

    public DateTime FechaLimitePago { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
