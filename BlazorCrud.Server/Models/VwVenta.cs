using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwVenta
{
    public int Folio { get; set; }

    public DateTime FechaVenta { get; set; }

    public int PagoId { get; set; }

    public int ClienteId { get; set; }

    public string Apellido1Cli { get; set; } = null!;

    public string Apellido2Cli { get; set; } = null!;

    public string NombreCli { get; set; } = null!;

    public int TipoId { get; set; }

    public int EntregaId { get; set; }

    public string? DescripcionEntrega { get; set; }

    public string MetodoEntrega { get; set; } = null!;

    public string Apellido1Emp { get; set; } = null!;

    public string Apellido2Emp { get; set; } = null!;

    public int EmpleadoId { get; set; }

    public DateTime FechaContrato { get; set; }

    public string? NombreEmp { get; set; }

    public string RfcEmp { get; set; } = null!;
}
