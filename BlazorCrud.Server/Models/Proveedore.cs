using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string Compañia { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
