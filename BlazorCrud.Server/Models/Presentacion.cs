using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Presentacion
{
    public int PresentacionId { get; set; }

    public string? NombrePresent { get; set; }

    public string? DescripcionPresent { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
