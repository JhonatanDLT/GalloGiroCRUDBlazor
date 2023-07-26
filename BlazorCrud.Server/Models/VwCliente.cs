using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwCliente
{
    public int ClienteId { get; set; }

    public string Apellido1Cli { get; set; } = null!;

    public string Apellido2Cli { get; set; } = null!;

    public string NombreCli { get; set; } = null!;

    public int TipoId { get; set; }

    public string? DescripcionTipo { get; set; }

    public string NombreTipo { get; set; } = null!;
}
