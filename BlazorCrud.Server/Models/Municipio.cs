using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Municipio
{
    public int MunId { get; set; }

    public string NombreMun { get; set; } = null!;

    public virtual ICollection<ZonasMun> ZonasMuns { get; set; } = new List<ZonasMun>();
}
