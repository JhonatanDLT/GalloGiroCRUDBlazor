using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string NombreCli { get; set; } = null!;

    public string Apellido1Cli { get; set; } = null!;

    public string Apellido2Cli { get; set; } = null!;

    public int TipoId { get; set; }

    public virtual ICollection<CreditoCli> CreditoClis { get; set; } = new List<CreditoCli>();

    public virtual TipoCliente Tipo { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
