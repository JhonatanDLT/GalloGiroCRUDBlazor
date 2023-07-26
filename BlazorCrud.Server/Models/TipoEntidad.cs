using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class TipoEntidad
{
    public int TipoEntId { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();
}
