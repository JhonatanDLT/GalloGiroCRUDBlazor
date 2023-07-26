using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwVentasDetalle
{
    public decimal? Precioventa { get; set; }

    public int Cantidad { get; set; }

    public float Descuento { get; set; }

    public int Folio { get; set; }

    public int ClienteId { get; set; }

    public int EmpleadoId { get; set; }

    public int EntregaId { get; set; }

    public int PagoId { get; set; }

    public DateTime FechaVenta { get; set; }

    public int ProductoId { get; set; }

    public string NombreProd { get; set; } = null!;

    public string? Marca { get; set; }

    public decimal Preciocompra { get; set; }

    public string? ComponenteActivo { get; set; }

    public string Upc { get; set; } = null!;
}
