using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MakiYumpuSAC.Models;

public partial class MakiYumpuSacContext : DbContext
{
    public MakiYumpuSacContext()
    {
    }

    public MakiYumpuSacContext(DbContextOptions<MakiYumpuSacContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CardexMaterial> CardexMaterials { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleFormPedido> DetalleFormPedidos { get; set; }

    public virtual DbSet<DetalleFt> DetalleFts { get; set; }

    public virtual DbSet<DetalleOc> DetalleOcs { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<FichaTecnica> FichaTecnicas { get; set; }

    public virtual DbSet<FormPedido> FormPedidos { get; set; }

    public virtual DbSet<ImgFichaTecnica> ImgFichaTecnicas { get; set; }

    public virtual DbSet<ImgFormPedido> ImgFormPedidos { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialBase> MaterialBases { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MakiYumpuDBConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardexMaterial>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PK__CARDEX_MATERIAL");

            entity.ToTable("CARDEX_MATERIAL");

            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Conos).HasColumnName("conos");
            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.Stock)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("stock");
            entity.Property(e => e.Tipo)
                .HasDefaultValue(true)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany()
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CARDEX_MA__id_ma__4316F928");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTE__677F38F51656479A");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo_cliente");
            entity.Property(e => e.NombreCompletoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_completo_cliente");
            entity.Property(e => e.PaisCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais_cliente");
        });

        modelBuilder.Entity<DetalleFormPedido>(entity =>
        {
            entity.HasKey(e => e.IdDetFormPedido).HasName("PK__DETALLE___B60583E52DE61B18");

            entity.ToTable("DETALLE_FORM_PEDIDO");

            entity.Property(e => e.IdDetFormPedido).HasColumnName("id_det_form_pedido");
            entity.Property(e => e.CantidadPrenda).HasColumnName("cantidad_prenda");
            entity.Property(e => e.DescPrenda)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("desc_prenda");
            entity.Property(e => e.DetallesPrenda)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("detalles_prenda");
            entity.Property(e => e.IdFormPedido).HasColumnName("id_form_pedido");

            entity.HasOne(d => d.IdFormPedidoNavigation).WithMany(p => p.DetalleFormPedidos)
                .HasForeignKey(d => d.IdFormPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_F__id_fo__5629CD9C");
        });

        modelBuilder.Entity<DetalleFt>(entity =>
        {
            entity.HasKey(e => e.IdDetFt).HasName("PK__DETALLE___E90F8F3888F791AB");

            entity.ToTable("DETALLE_FT");

            entity.Property(e => e.IdDetFt).HasColumnName("id_det_ft");
            entity.Property(e => e.IdFichaTecnica).HasColumnName("id_ficha_tecnica");
            entity.Property(e => e.IdMaterial).HasColumnName("id_material");

            entity.HasOne(d => d.IdFichaTecnicaNavigation).WithMany(p => p.DetalleFts)
                .HasForeignKey(d => d.IdFichaTecnica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_F__id_fi__0A9D95DB");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.DetalleFts)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_F__id_ma__0B91BA14");
        });

        modelBuilder.Entity<DetalleOc>(entity =>
        {
            entity.HasKey(e => new { e.IdMaterial, e.IdOcm }).HasName("PK__DETALLE___3709761F1A3C0C46");

            entity.ToTable("DETALLE_OC");

            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.IdOcm).HasColumnName("id_ocm");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("money")
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.DetalleOcs)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_O__id_ma__5DCAEF64");

            entity.HasOne(d => d.IdOcmNavigation).WithMany(p => p.DetalleOcs)
                .HasForeignKey(d => d.IdOcm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_O__id_oc__5EBF139D");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetPedido).HasName("PK__DETALLE___3D43846198A6AEE5");

            entity.ToTable("DETALLE_PEDIDO");

            entity.Property(e => e.IdDetPedido).HasColumnName("id_det_pedido");
            entity.Property(e => e.CantidadPrenda).HasColumnName("cantidad_prenda");
            entity.Property(e => e.IdFichaTecnica).HasColumnName("id_ficha_tecnica");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("money")
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.IdFichaTecnicaNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdFichaTecnica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_P__id_fi__06CD04F7");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_P__id_pe__07C12930");
        });

        modelBuilder.Entity<FichaTecnica>(entity =>
        {
            entity.HasKey(e => e.IdFichaTecnica).HasName("PK__FICHA_TE__96E2E4B326E4E279");

            entity.ToTable("FICHA_TECNICA");

            entity.Property(e => e.IdFichaTecnica).HasColumnName("id_ficha_tecnica");
            entity.Property(e => e.AcabadosDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("acabados_desc");
            entity.Property(e => e.ArmadoDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("armado_desc");
            entity.Property(e => e.DescPrenda)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("desc_prenda");
            entity.Property(e => e.FechaFt)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ft");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.OtrosMaterialesDesc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("otros_materiales_desc");
            entity.Property(e => e.PesoPrenda)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("peso_prenda");
            entity.Property(e => e.TallaPrenda)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("talla_prenda");
            entity.Property(e => e.TejidoDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("tejido_desc");
            entity.Property(e => e.VaporizadoDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("vaporizado_desc");
        });

        modelBuilder.Entity<FormPedido>(entity =>
        {
            entity.HasKey(e => e.IdFormPedido).HasName("PK__FORM_PED__CD6CC369E97A6EF5");

            entity.ToTable("FORM_PEDIDO");

            entity.Property(e => e.IdFormPedido).HasColumnName("id_form_pedido");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo_cliente");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.NombreCompletoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_completo_cliente");
            entity.Property(e => e.PaisCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais_cliente");
        });

        modelBuilder.Entity<ImgFichaTecnica>(entity =>
        {
            entity.HasKey(e => e.IdImgFt).HasName("PK__IMG_FICH__4687A08F2A29530E");

            entity.ToTable("IMG_FICHA_TECNICA");

            entity.Property(e => e.IdImgFt).HasColumnName("id_img_ft");
            entity.Property(e => e.IdFichaTecnica).HasColumnName("id_ficha_tecnica");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_imagen");

            entity.HasOne(d => d.IdFichaTecnicaNavigation).WithMany(p => p.ImgFichaTecnicas)
                .HasForeignKey(d => d.IdFichaTecnica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IMG_FICHA__id_fi__0E6E26BF");
        });

        modelBuilder.Entity<ImgFormPedido>(entity =>
        {
            entity.HasKey(e => e.IdImgFormPedido).HasName("PK__IMG_FORM__79674D65AD108725");

            entity.ToTable("IMG_FORM_PEDIDO");

            entity.Property(e => e.IdImgFormPedido).HasColumnName("id_img_form_pedido");
            entity.Property(e => e.IdFormPedido).HasColumnName("id_form_pedido");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_imagen");

            entity.HasOne(d => d.IdFormPedidoNavigation).WithMany(p => p.ImgFormPedidos)
                .HasForeignKey(d => d.IdFormPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IMG_FORM___id_fo__03F0984C");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PK__MATERIAL__81E99B83F6862540");

            entity.ToTable("MATERIAL");

            entity.HasIndex(e => new { e.IdMaterialBase, e.IdPantone, e.Hebras }, "UQ__MATERIAL__B586E7C0C0D9F1D6").IsUnique();

            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.Hebras)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("hebras");
            entity.Property(e => e.IdMaterialBase)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("id_material_base");
            entity.Property(e => e.IdPantone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("id_pantone");

            entity.HasOne(d => d.IdMaterialBaseNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdMaterialBase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MATERIAL__id_mat__403A8C7D");
        });

        modelBuilder.Entity<MaterialBase>(entity =>
        {
            entity.HasKey(e => e.IdMaterialBase).HasName("PK__MATERIAL__AB78780E1706B4D7");

            entity.ToTable("MATERIAL_BASE");

            entity.Property(e => e.IdMaterialBase)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("id_material_base");
            entity.Property(e => e.DescMaterial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("desc_material");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOcm).HasName("PK__ORDEN_CO__6E0ED9CA1C242ADE");

            entity.ToTable("ORDEN_COMPRA");

            entity.Property(e => e.IdOcm).HasColumnName("id_ocm");
            entity.Property(e => e.EstadoOc).HasColumnName("estado_oc");
            entity.Property(e => e.FechaOc)
                .HasColumnType("datetime")
                .HasColumnName("fecha_oc");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__PEDIDO__6FF01489C9DB689D");

            entity.ToTable("PEDIDO");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.EstadoPedidoId)
                .HasDefaultValue(1)
                .HasColumnName("estado_pedido_id");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaGeneracionPedido)
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion_pedido");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PEDIDO__id_clien__46E78A0C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PEDIDO__id_usuar__47DBAE45");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__4E3E04AD6D6362D2");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.DniUsuario, "UQ__USUARIO__B68C02517C4CCB72").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ApMatUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ap_mat_usuario");
            entity.Property(e => e.ApPatUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ap_pat_usuario");
            entity.Property(e => e.DniUsuario)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dni_usuario");
            entity.Property(e => e.EsAdmin).HasColumnName("es_admin");
            entity.Property(e => e.FechaNacUsuario)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nac_usuario");
            entity.Property(e => e.LoginUsuario)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("login_usuario");
            entity.Property(e => e.NombresUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres_usuario");
            entity.Property(e => e.PasswordUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
