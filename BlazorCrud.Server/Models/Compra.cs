using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Compra
{
    public int Folio { get; set; }

    public int EmpleadoId { get; set; }

    public int ProveedorId { get; set; }

    public DateTime FechaCompra { get; set; }

    public virtual ICollection<ComprasDetalle> ComprasDetalles { get; set; } = new List<ComprasDetalle>();

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proveedore Proveedor { get; set; } = null!;
}
