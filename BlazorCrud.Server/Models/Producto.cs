using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string NombreProd { get; set; } = null!;

    public string? Marca { get; set; }

    public int PresentacionId { get; set; }

    public int FamId { get; set; }

    public int ProveedorId { get; set; }

    public decimal Preciocompra { get; set; }

    public decimal Precioventa { get; set; }

    public decimal Descuento { get; set; }

    public string? ComponenteActivo { get; set; }

    public string Upc { get; set; } = null!;

    public virtual ICollection<ComprasDetalle> ComprasDetalles { get; set; } = new List<ComprasDetalle>();

    public virtual Familia Fam { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual Presentacion Presentacion { get; set; } = null!;

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual ICollection<TrasladosInventario> TrasladosInventarios { get; set; } = new List<TrasladosInventario>();

    public virtual ICollection<VentasDetalle> VentasDetalles { get; set; } = new List<VentasDetalle>();
}
