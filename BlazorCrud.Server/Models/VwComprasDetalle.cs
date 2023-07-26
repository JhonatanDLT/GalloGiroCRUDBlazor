using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwComprasDetalle
{
    public int Cantidad { get; set; }

    public decimal Preciocompra { get; set; }

    public int Folio { get; set; }

    public int EmpleadoId { get; set; }

    public int ProveedorId { get; set; }

    public DateTime FechaCompra { get; set; }

    public int ProductoId { get; set; }

    public string NombreProd { get; set; } = null!;

    public string? Marca { get; set; }

    public decimal Precioventa { get; set; }

    public decimal Descuento { get; set; }

    public string? ComponenteActivo { get; set; }

    public string Upc { get; set; } = null!;
}
