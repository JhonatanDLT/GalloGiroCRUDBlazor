using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Entidad
{
    public int EntidadId { get; set; }

    public string NombreEnt { get; set; } = null!;

    public int TipoEntId { get; set; }

    public int ZonaId { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual TipoEntidad TipoEnt { get; set; } = null!;

    public virtual ICollection<TrasladosInventario> TrasladosInventarioDestinos { get; set; } = new List<TrasladosInventario>();

    public virtual ICollection<TrasladosInventario> TrasladosInventarioOrigens { get; set; } = new List<TrasladosInventario>();

    public virtual Zona Zona { get; set; } = null!;
}
