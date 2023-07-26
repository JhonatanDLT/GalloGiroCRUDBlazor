using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwCreditoCli
{
    public int CreditoId { get; set; }

    public DateTime FechaCompra { get; set; }

    public DateTime FechaLimitePago { get; set; }

    public decimal MontoTotal { get; set; }

    public int ClienteId { get; set; }

    public string Apellido1Cli { get; set; } = null!;

    public string Apellido2Cli { get; set; } = null!;

    public string NombreCli { get; set; } = null!;

    public int TipoId { get; set; }
}
