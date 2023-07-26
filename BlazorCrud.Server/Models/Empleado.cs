using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? NombreEmp { get; set; }

    public string Apellido1Cli { get; set; } = null!;

    public string Apellido2Cli { get; set; } = null!;

    public string RfcEmp { get; set; } = null!;

    public DateTime FechaContrato { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
