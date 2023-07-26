using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwCompra
{
    public int Folio { get; set; }

    public DateTime FechaCompra { get; set; }

    public int ProveedorId { get; set; }

    public string Compañia { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Apellido1Cli { get; set; } = null!;

    public string Apellido2Cli { get; set; } = null!;

    public int EmpleadoId { get; set; }

    public DateTime FechaContrato { get; set; }

    public string? NombreEmp { get; set; }

    public string RfcEmp { get; set; } = null!;
}
