using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Venta
{
    public int Folio { get; set; }

    public int EmpleadoId { get; set; }

    public int ClienteId { get; set; }

    public DateTime FechaVenta { get; set; }

    public int EntregaId { get; set; }

    public int PagoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Entrega Entrega { get; set; } = null!;

    public virtual ICollection<VentasDetalle> VentasDetalles { get; set; } = new List<VentasDetalle>();
}
