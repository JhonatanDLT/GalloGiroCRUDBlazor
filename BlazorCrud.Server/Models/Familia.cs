using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Familia
{
    public int FamId { get; set; }

    public string NombreFam { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
