using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class VwProducto
{
    public int ProductoId { get; set; }

    public string NombreProd { get; set; } = null!;

    public string? Marca { get; set; }

    public decimal Preciocompra { get; set; }

    public decimal Precioventa { get; set; }

    public decimal Descuento { get; set; }

    public string? ComponenteActivo { get; set; }

    public string Upc { get; set; } = null!;

    public int ProveedorId { get; set; }

    public string Compañia { get; set; } = null!;

    public string? Direccion { get; set; }

    public int FamId { get; set; }

    public string NombreFam { get; set; } = null!;

    public int PresentacionId { get; set; }

    public string? NombrePresent { get; set; }

    public string? DescripcionPresent { get; set; }
}
