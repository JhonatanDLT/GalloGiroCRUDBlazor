using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class TipoCliente
{
    public int TipoId { get; set; }

    public string NombreTipo { get; set; } = null!;

    public string? DescripcionTipo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
