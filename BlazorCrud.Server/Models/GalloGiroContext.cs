using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Models;

public partial class GalloGiroContext : DbContext
{
    public GalloGiroContext()
    {
    }

    public GalloGiroContext(DbContextOptions<GalloGiroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<ComprasDetalle> ComprasDetalles { get; set; }

    public virtual DbSet<CreditoCli> CreditoClis { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Entidad> Entidads { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<Familia> Familias { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Presentacion> Presentacions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoEntidad> TipoEntidads { get; set; }

    public virtual DbSet<TrasladosInventario> TrasladosInventarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<VentasDetalle> VentasDetalles { get; set; }

    public virtual DbSet<VwCliente> VwClientes { get; set; }

    public virtual DbSet<VwCompra> VwCompras { get; set; }

    public virtual DbSet<VwComprasDetalle> VwComprasDetalles { get; set; }

    public virtual DbSet<VwCreditoCli> VwCreditoClis { get; set; }

    public virtual DbSet<VwEntidad> VwEntidads { get; set; }

    public virtual DbSet<VwInventario> VwInventarios { get; set; }

    public virtual DbSet<VwProducto> VwProductos { get; set; }

    public virtual DbSet<VwVenta> VwVentas { get; set; }

    public virtual DbSet<VwVentasDetalle> VwVentasDetalles { get; set; }

    public virtual DbSet<VwZonasMun> VwZonasMuns { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    public virtual DbSet<ZonasMun> ZonasMuns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("cliente_ID");
            entity.Property(e => e.Apellido1Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Cli");
            entity.Property(e => e.Apellido2Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Cli");
            entity.Property(e => e.NombreCli)
                .HasMaxLength(50)
                .HasColumnName("nombre_Cli");
            entity.Property(e => e.TipoId).HasColumnName("tipo_ID");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.TipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Tipo_Cliente");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Folio);

            entity.ToTable("Compras", "Compras");

            entity.Property(e => e.Folio)
                .ValueGeneratedNever()
                .HasColumnName("folio");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_ID");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_Compra");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_ID");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Compras)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Empleados");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Proveedores");
        });

        modelBuilder.Entity<ComprasDetalle>(entity =>
        {
            entity.HasKey(e => new { e.Folio, e.ProductId });

            entity.ToTable("Compras_Detalles", "Compras");

            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.ProductId).HasColumnName("product_ID");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Preciocompra)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("preciocompra");

            entity.HasOne(d => d.FolioNavigation).WithMany(p => p.ComprasDetalles)
                .HasForeignKey(d => d.Folio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Detalles_Compras");

            entity.HasOne(d => d.Product).WithMany(p => p.ComprasDetalles)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_Detalles_Productos");
        });

        modelBuilder.Entity<CreditoCli>(entity =>
        {
            entity.HasKey(e => e.CreditoId);

            entity.ToTable("Credito_Cli");

            entity.Property(e => e.CreditoId)
                .ValueGeneratedNever()
                .HasColumnName("credito_ID");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_ID");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.FechaLimitePago)
                .HasColumnType("date")
                .HasColumnName("fecha_limite_pago");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CreditoClis)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Credito_Cli_Clientes");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("Empleados", "RecursosHumanos");

            entity.Property(e => e.EmpleadoId)
                .ValueGeneratedNever()
                .HasColumnName("empleado_ID");
            entity.Property(e => e.Apellido1Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Cli");
            entity.Property(e => e.Apellido2Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Cli");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_Contrato");
            entity.Property(e => e.NombreEmp)
                .HasMaxLength(75)
                .HasColumnName("nombre_emp");
            entity.Property(e => e.RfcEmp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RFC_Emp");
        });

        modelBuilder.Entity<Entidad>(entity =>
        {
            entity.ToTable("Entidad");

            entity.Property(e => e.EntidadId)
                .ValueGeneratedNever()
                .HasColumnName("entidad_ID");
            entity.Property(e => e.NombreEnt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_ent");
            entity.Property(e => e.TipoEntId).HasColumnName("tipo_ent_ID");
            entity.Property(e => e.ZonaId).HasColumnName("zona_ID");

            entity.HasOne(d => d.TipoEnt).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.TipoEntId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entidad_Tipo_Entidad");

            entity.HasOne(d => d.Zona).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entidad_Zonas");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.ToTable("Entregas", "Ventas");

            entity.Property(e => e.EntregaId)
                .ValueGeneratedNever()
                .HasColumnName("entrega_ID");
            entity.Property(e => e.DescripcionEntrega)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_Entrega");
            entity.Property(e => e.MetodoEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_Entrega");
        });

        modelBuilder.Entity<Familia>(entity =>
        {
            entity.HasKey(e => e.FamId);

            entity.ToTable("Familias", "Productos");

            entity.Property(e => e.FamId)
                .ValueGeneratedNever()
                .HasColumnName("fam_ID");
            entity.Property(e => e.NombreFam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Fam");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.ToTable("Inventario", "Inventario");

            entity.Property(e => e.InventarioId)
                .ValueGeneratedNever()
                .HasColumnName("inventario_ID");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.EntidadId).HasColumnName("entidad_ID");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.Reorden).HasColumnName("reorden");

            entity.HasOne(d => d.Entidad).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.EntidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Entidad");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Productos");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.MunId);

            entity.Property(e => e.MunId)
                .ValueGeneratedNever()
                .HasColumnName("mun_ID");
            entity.Property(e => e.NombreMun)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Mun");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.ToTable("Presentacion", "Productos");

            entity.Property(e => e.PresentacionId)
                .ValueGeneratedNever()
                .HasColumnName("presentacion_ID");
            entity.Property(e => e.DescripcionPresent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_present");
            entity.Property(e => e.NombrePresent)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("nombre_Present");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("producto_ID");
            entity.Property(e => e.ComponenteActivo)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("componente_Activo");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(3, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.FamId).HasColumnName("fam_ID");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Prod");
            entity.Property(e => e.Preciocompra)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("preciocompra");
            entity.Property(e => e.Precioventa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precioventa");
            entity.Property(e => e.PresentacionId).HasColumnName("presentacion_ID");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_ID");
            entity.Property(e => e.Upc)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UPC");

            entity.HasOne(d => d.Fam).WithMany(p => p.Productos)
                .HasForeignKey(d => d.FamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Familias");

            entity.HasOne(d => d.Presentacion).WithMany(p => p.Productos)
                .HasForeignKey(d => d.PresentacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Presentacion");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Proveedores");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId);

            entity.ToTable("Proveedores", "Compras");

            entity.Property(e => e.ProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("proveedor_ID");
            entity.Property(e => e.Compañia)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("compañia");
            entity.Property(e => e.Direccion)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("direccion");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK_Tipo_Cliente");

            entity.ToTable("Tipo Cliente");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("tipo_ID");
            entity.Property(e => e.DescripcionTipo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion_tipo");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
        });

        modelBuilder.Entity<TipoEntidad>(entity =>
        {
            entity.HasKey(e => e.TipoEntId);

            entity.ToTable("Tipo_Entidad");

            entity.Property(e => e.TipoEntId)
                .ValueGeneratedNever()
                .HasColumnName("tipo_ent_ID");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
        });

        modelBuilder.Entity<TrasladosInventario>(entity =>
        {
            entity.HasKey(e => e.TrasladoId);

            entity.ToTable("TrasladosInventario", "Inventario");

            entity.Property(e => e.TrasladoId)
                .ValueGeneratedNever()
                .HasColumnName("traslado_ID");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DestinoId).HasColumnName("destino_ID");
            entity.Property(e => e.FechaTraslado)
                .HasColumnType("date")
                .HasColumnName("fecha_traslado");
            entity.Property(e => e.OrigenId).HasColumnName("origen_ID");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.Razon)
                .HasMaxLength(250)
                .HasColumnName("razon");

            entity.HasOne(d => d.Destino).WithMany(p => p.TrasladosInventarioDestinos)
                .HasForeignKey(d => d.DestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrasladosInventario_Destino");

            entity.HasOne(d => d.Origen).WithMany(p => p.TrasladosInventarioOrigens)
                .HasForeignKey(d => d.OrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrasladosInventario_Origen");

            entity.HasOne(d => d.Producto).WithMany(p => p.TrasladosInventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrasladosInventario_Productos");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Folio);

            entity.ToTable("Ventas", "Ventas");

            entity.Property(e => e.Folio)
                .ValueGeneratedNever()
                .HasColumnName("folio");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_ID");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_ID");
            entity.Property(e => e.EntregaId).HasColumnName("entrega_ID");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fecha_Venta");
            entity.Property(e => e.PagoId).HasColumnName("pago_ID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Clientes");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Venta)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Empleados");

            entity.HasOne(d => d.Entrega).WithMany(p => p.Venta)
                .HasForeignKey(d => d.EntregaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Entregas");
        });

        modelBuilder.Entity<VentasDetalle>(entity =>
        {
            entity.HasKey(e => new { e.Folio, e.ProductoId });

            entity.ToTable("Ventas_Detalles", "Ventas");

            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.Precioventa)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precioventa");

            entity.HasOne(d => d.FolioNavigation).WithMany(p => p.VentasDetalles)
                .HasForeignKey(d => d.Folio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Detalles_Ventas");

            entity.HasOne(d => d.Producto).WithMany(p => p.VentasDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Detalles_Productos");
        });

        modelBuilder.Entity<VwCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_clientes");

            entity.Property(e => e.Apellido1Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Cli");
            entity.Property(e => e.Apellido2Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Cli");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_ID");
            entity.Property(e => e.DescripcionTipo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion_tipo");
            entity.Property(e => e.NombreCli)
                .HasMaxLength(50)
                .HasColumnName("nombre_Cli");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
            entity.Property(e => e.TipoId).HasColumnName("tipo_ID");
        });

        modelBuilder.Entity<VwCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_compras", "Compras");

            entity.Property(e => e.Apellido1Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Cli");
            entity.Property(e => e.Apellido2Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Cli");
            entity.Property(e => e.Compañia)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("compañia");
            entity.Property(e => e.Direccion)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_ID");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_Compra");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_Contrato");
            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.NombreEmp)
                .HasMaxLength(75)
                .HasColumnName("nombre_emp");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_ID");
            entity.Property(e => e.RfcEmp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RFC_Emp");
        });

        modelBuilder.Entity<VwComprasDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_compras_detalles", "Compras");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ComponenteActivo)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("componente_Activo");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(3, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_ID");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_Compra");
            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Prod");
            entity.Property(e => e.Preciocompra)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("preciocompra");
            entity.Property(e => e.Precioventa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precioventa");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_ID");
            entity.Property(e => e.Upc)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UPC");
        });

        modelBuilder.Entity<VwCreditoCli>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_credito_Cli");

            entity.Property(e => e.Apellido1Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Cli");
            entity.Property(e => e.Apellido2Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Cli");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_ID");
            entity.Property(e => e.CreditoId).HasColumnName("credito_ID");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.FechaLimitePago)
                .HasColumnType("date")
                .HasColumnName("fecha_limite_pago");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_total");
            entity.Property(e => e.NombreCli)
                .HasMaxLength(50)
                .HasColumnName("nombre_Cli");
            entity.Property(e => e.TipoId).HasColumnName("tipo_ID");
        });

        modelBuilder.Entity<VwEntidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Entidad");

            entity.Property(e => e.DescripcionZona)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion_Zona");
            entity.Property(e => e.EntidadId).HasColumnName("entidad_ID");
            entity.Property(e => e.NombreEnt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_ent");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
            entity.Property(e => e.NombreZona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_zona");
            entity.Property(e => e.TipoEntId).HasColumnName("tipo_ent_ID");
            entity.Property(e => e.ZonaId).HasColumnName("zona_ID");
        });

        modelBuilder.Entity<VwInventario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_inventario", "Inventario");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.EntidadId).HasColumnName("entidad_ID");
            entity.Property(e => e.InventarioId).HasColumnName("inventario_ID");
            entity.Property(e => e.NombreEnt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_ent");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.Reorden).HasColumnName("reorden");
            entity.Property(e => e.TipoEntId).HasColumnName("tipo_ent_ID");
            entity.Property(e => e.ZonaId).HasColumnName("zona_ID");
        });

        modelBuilder.Entity<VwProducto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_productos", "Productos");

            entity.Property(e => e.Compañia)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("compañia");
            entity.Property(e => e.ComponenteActivo)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("componente_Activo");
            entity.Property(e => e.DescripcionPresent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_present");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(3, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.Direccion)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FamId).HasColumnName("fam_ID");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NombreFam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Fam");
            entity.Property(e => e.NombrePresent)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("nombre_present");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Prod");
            entity.Property(e => e.Preciocompra)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("preciocompra");
            entity.Property(e => e.Precioventa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precioventa");
            entity.Property(e => e.PresentacionId).HasColumnName("presentacion_ID");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_ID");
            entity.Property(e => e.Upc)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UPC");
        });

        modelBuilder.Entity<VwVenta>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ventas", "Ventas");

            entity.Property(e => e.Apellido1Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Cli");
            entity.Property(e => e.Apellido1Emp)
                .HasMaxLength(50)
                .HasColumnName("apellido_1_Emp");
            entity.Property(e => e.Apellido2Cli)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Cli");
            entity.Property(e => e.Apellido2Emp)
                .HasMaxLength(50)
                .HasColumnName("apellido_2_Emp");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_ID");
            entity.Property(e => e.DescripcionEntrega)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion_Entrega");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_ID");
            entity.Property(e => e.EntregaId).HasColumnName("entrega_ID");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_Contrato");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fecha_Venta");
            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.MetodoEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_Entrega");
            entity.Property(e => e.NombreCli)
                .HasMaxLength(50)
                .HasColumnName("nombre_Cli");
            entity.Property(e => e.NombreEmp)
                .HasMaxLength(75)
                .HasColumnName("nombre_emp");
            entity.Property(e => e.PagoId).HasColumnName("pago_ID");
            entity.Property(e => e.RfcEmp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RFC_Emp");
            entity.Property(e => e.TipoId).HasColumnName("tipo_ID");
        });

        modelBuilder.Entity<VwVentasDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ventas_detalles", "Ventas");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_ID");
            entity.Property(e => e.ComponenteActivo)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("componente_Activo");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_ID");
            entity.Property(e => e.EntregaId).HasColumnName("entrega_ID");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fecha_Venta");
            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Prod");
            entity.Property(e => e.PagoId).HasColumnName("pago_ID");
            entity.Property(e => e.Preciocompra)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("preciocompra");
            entity.Property(e => e.Precioventa)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precioventa");
            entity.Property(e => e.ProductoId).HasColumnName("producto_ID");
            entity.Property(e => e.Upc)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UPC");
        });

        modelBuilder.Entity<VwZonasMun>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_zonas_mun", "Ventas");

            entity.Property(e => e.DescripcionZona)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion_Zona");
            entity.Property(e => e.MunId).HasColumnName("mun_ID");
            entity.Property(e => e.NombreMun)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Mun");
            entity.Property(e => e.NombreZona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_zona");
            entity.Property(e => e.ZonaId).HasColumnName("zona_ID");
            entity.Property(e => e.ZonasMunId).HasColumnName("zonas_mun_ID");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.Property(e => e.ZonaId)
                .ValueGeneratedNever()
                .HasColumnName("zona_ID");
            entity.Property(e => e.DescripcionZona)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion_Zona");
            entity.Property(e => e.MunId).HasColumnName("mun_ID");
            entity.Property(e => e.NombreZona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Zona");
        });

        modelBuilder.Entity<ZonasMun>(entity =>
        {
            entity.ToTable("Zonas_Mun");

            entity.Property(e => e.ZonasMunId)
                .ValueGeneratedNever()
                .HasColumnName("zonas_mun_ID");
            entity.Property(e => e.MunId).HasColumnName("mun_ID");
            entity.Property(e => e.ZonaId).HasColumnName("zona_ID");

            entity.HasOne(d => d.Mun).WithMany(p => p.ZonasMuns)
                .HasForeignKey(d => d.MunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Zonas_Mun_Mun");

            entity.HasOne(d => d.Zona).WithMany(p => p.ZonasMuns)
                .HasForeignKey(d => d.ZonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_Mun_Zona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
