using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class ZonasMun
{
    public int ZonasMunId { get; set; }

    public int MunId { get; set; }

    public int ZonaId { get; set; }

    public virtual Municipio Mun { get; set; } = null!;

    public virtual Zona Zona { get; set; } = null!;
}
