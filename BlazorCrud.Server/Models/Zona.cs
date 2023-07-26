using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Zona
{
    public int ZonaId { get; set; }

    public string NombreZona { get; set; } = null!;

    public string? DescripcionZona { get; set; }

    public int MunId { get; set; }

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();

    public virtual ICollection<ZonasMun> ZonasMuns { get; set; } = new List<ZonasMun>();
}
