﻿// <auto-generated />
using System;
using MakiYumpuSAC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MakiYumpuSAC.Migrations
{
    [DbContext(typeof(MakiYumpuSacContext))]
    [Migration("20240222222024_Activos")]
    partial class Activos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MakiYumpuSAC.Models.CardexMaterial", b =>
                {
                    b.Property<int>("IdMaterial")
                        .HasColumnType("int")
                        .HasColumnName("id_material");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("cantidad");

                    b.Property<short?>("Conos")
                        .HasColumnType("smallint")
                        .HasColumnName("conos");

                    b.Property<decimal>("Stock")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("stock");

                    b.Property<bool>("Tipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("tipo");

                    b.HasKey("IdMaterial")
                        .HasName("PK__CARDEX_MATERIAL");

                    b.ToTable("CARDEX_MATERIAL", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("CorreoCliente")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("correo_cliente");

                    b.Property<string>("NombreCompletoCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_completo_cliente");

                    b.Property<string>("PaisCliente")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("pais_cliente");

                    b.HasKey("IdCliente")
                        .HasName("PK__CLIENTE__677F38F51656479A");

                    b.ToTable("CLIENTE", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetalleFormPedido", b =>
                {
                    b.Property<int>("IdDetFormPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_det_form_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetFormPedido"));

                    b.Property<int>("CantidadPrenda")
                        .HasColumnType("int")
                        .HasColumnName("cantidad_prenda");

                    b.Property<string>("DescPrenda")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("desc_prenda");

                    b.Property<string>("DetallesPrenda")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("detalles_prenda");

                    b.Property<int>("IdFormPedido")
                        .HasColumnType("int")
                        .HasColumnName("id_form_pedido");

                    b.HasKey("IdDetFormPedido")
                        .HasName("PK__DETALLE___B60583E52DE61B18");

                    b.HasIndex("IdFormPedido");

                    b.ToTable("DETALLE_FORM_PEDIDO", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetalleFt", b =>
                {
                    b.Property<int>("IdDetFt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_det_ft");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetFt"));

                    b.Property<int>("IdFichaTecnica")
                        .HasColumnType("int")
                        .HasColumnName("id_ficha_tecnica");

                    b.Property<int>("IdMaterial")
                        .HasColumnType("int")
                        .HasColumnName("id_material");

                    b.HasKey("IdDetFt")
                        .HasName("PK__DETALLE___E90F8F3888F791AB");

                    b.HasIndex("IdFichaTecnica");

                    b.HasIndex("IdMaterial");

                    b.ToTable("DETALLE_FT", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetalleOc", b =>
                {
                    b.Property<int>("IdMaterial")
                        .HasColumnType("int")
                        .HasColumnName("id_material");

                    b.Property<int>("IdOcm")
                        .HasColumnType("int")
                        .HasColumnName("id_ocm");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("cantidad");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("money")
                        .HasColumnName("precio_unitario");

                    b.HasKey("IdMaterial", "IdOcm")
                        .HasName("PK__DETALLE___3709761F1A3C0C46");

                    b.HasIndex("IdOcm");

                    b.ToTable("DETALLE_OC", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetallePedido", b =>
                {
                    b.Property<int>("IdDetPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_det_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetPedido"));

                    b.Property<int>("CantidadPrenda")
                        .HasColumnType("int")
                        .HasColumnName("cantidad_prenda");

                    b.Property<int>("IdFichaTecnica")
                        .HasColumnType("int")
                        .HasColumnName("id_ficha_tecnica");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int")
                        .HasColumnName("id_pedido");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("money")
                        .HasColumnName("precio_unitario");

                    b.HasKey("IdDetPedido")
                        .HasName("PK__DETALLE___3D43846198A6AEE5");

                    b.HasIndex("IdFichaTecnica");

                    b.HasIndex("IdPedido");

                    b.ToTable("DETALLE_PEDIDO", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.FichaTecnica", b =>
                {
                    b.Property<int>("IdFichaTecnica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_ficha_tecnica");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFichaTecnica"));

                    b.Property<string>("AcabadosDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("acabados_desc");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ArmadoDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("armado_desc");

                    b.Property<string>("DescPrenda")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("desc_prenda");

                    b.Property<DateTime>("FechaFt")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_ft");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<string>("OtrosMaterialesDesc")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("otros_materiales_desc");

                    b.Property<decimal?>("PesoPrenda")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("peso_prenda");

                    b.Property<string>("TallaPrenda")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("talla_prenda");

                    b.Property<string>("TejidoDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("tejido_desc");

                    b.Property<string>("VaporizadoDesc")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("vaporizado_desc");

                    b.HasKey("IdFichaTecnica")
                        .HasName("PK__FICHA_TE__96E2E4B326E4E279");

                    b.ToTable("FICHA_TECNICA", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.FormPedido", b =>
                {
                    b.Property<int>("IdFormPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_form_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormPedido"));

                    b.Property<string>("CorreoCliente")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("correo_cliente");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<string>("NombreCompletoCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_completo_cliente");

                    b.Property<string>("PaisCliente")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("pais_cliente");

                    b.HasKey("IdFormPedido")
                        .HasName("PK__FORM_PED__CD6CC369E97A6EF5");

                    b.ToTable("FORM_PEDIDO", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.ImgFichaTecnica", b =>
                {
                    b.Property<int>("IdImgFt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_img_ft");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImgFt"));

                    b.Property<int>("IdFichaTecnica")
                        .HasColumnType("int")
                        .HasColumnName("id_ficha_tecnica");

                    b.Property<string>("RutaImagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ruta_imagen");

                    b.HasKey("IdImgFt")
                        .HasName("PK__IMG_FICH__4687A08F2A29530E");

                    b.HasIndex("IdFichaTecnica");

                    b.ToTable("IMG_FICHA_TECNICA", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.ImgFormPedido", b =>
                {
                    b.Property<int>("IdImgFormPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_img_form_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImgFormPedido"));

                    b.Property<int>("IdFormPedido")
                        .HasColumnType("int")
                        .HasColumnName("id_form_pedido");

                    b.Property<string>("RutaImagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ruta_imagen");

                    b.HasKey("IdImgFormPedido")
                        .HasName("PK__IMG_FORM__79674D65AD108725");

                    b.HasIndex("IdFormPedido");

                    b.ToTable("IMG_FORM_PEDIDO", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Material", b =>
                {
                    b.Property<int>("IdMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_material");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaterial"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Hebras")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("hebras");

                    b.Property<string>("IdMaterialBase")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("id_material_base");

                    b.Property<string>("IdPantone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("id_pantone");

                    b.HasKey("IdMaterial")
                        .HasName("PK__MATERIAL__81E99B83F6862540");

                    b.HasIndex(new[] { "IdMaterialBase", "IdPantone", "Hebras" }, "UQ__MATERIAL__B586E7C0C0D9F1D6")
                        .IsUnique();

                    b.ToTable("MATERIAL", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.MaterialBase", b =>
                {
                    b.Property<string>("IdMaterialBase")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("id_material_base");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("DescMaterial")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("desc_material");

                    b.HasKey("IdMaterialBase")
                        .HasName("PK__MATERIAL__AB78780E1706B4D7");

                    b.ToTable("MATERIAL_BASE", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.OrdenCompra", b =>
                {
                    b.Property<int>("IdOcm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_ocm");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOcm"));

                    b.Property<bool>("EstadoOc")
                        .HasColumnType("bit")
                        .HasColumnName("estado_oc");

                    b.Property<DateTime>("FechaOc")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_oc");

                    b.HasKey("IdOcm")
                        .HasName("PK__ORDEN_CO__6E0ED9CA1C242ADE");

                    b.ToTable("ORDEN_COMPRA", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_pedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<int>("EstadoPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("estado_pedido_id");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_entrega");

                    b.Property<DateTime>("FechaGeneracionPedido")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_generacion_pedido");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.HasKey("IdPedido")
                        .HasName("PK__PEDIDO__6FF01489C9DB689D");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("PEDIDO", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ApMatUsuario")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ap_mat_usuario");

                    b.Property<string>("ApPatUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ap_pat_usuario");

                    b.Property<string>("DniUsuario")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("dni_usuario")
                        .IsFixedLength();

                    b.Property<bool>("EsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("es_admin");

                    b.Property<DateTime>("FechaNacUsuario")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_nac_usuario");

                    b.Property<string>("LoginUsuario")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("login_usuario")
                        .IsFixedLength();

                    b.Property<string>("NombresUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombres_usuario");

                    b.Property<string>("PasswordUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password_usuario");

                    b.HasKey("IdUsuario")
                        .HasName("PK__USUARIO__4E3E04AD6D6362D2");

                    b.HasIndex(new[] { "DniUsuario" }, "UQ__USUARIO__B68C02517C4CCB72")
                        .IsUnique();

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.CardexMaterial", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.Material", "IdMaterialNavigation")
                        .WithMany()
                        .HasForeignKey("IdMaterial")
                        .IsRequired()
                        .HasConstraintName("FK__CARDEX_MA__id_ma__4316F928");

                    b.Navigation("IdMaterialNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetalleFormPedido", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.FormPedido", "IdFormPedidoNavigation")
                        .WithMany("DetalleFormPedidos")
                        .HasForeignKey("IdFormPedido")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_F__id_fo__5629CD9C");

                    b.Navigation("IdFormPedidoNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetalleFt", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.FichaTecnica", "IdFichaTecnicaNavigation")
                        .WithMany("DetalleFts")
                        .HasForeignKey("IdFichaTecnica")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_F__id_fi__0A9D95DB");

                    b.HasOne("MakiYumpuSAC.Models.Material", "IdMaterialNavigation")
                        .WithMany("DetalleFts")
                        .HasForeignKey("IdMaterial")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_F__id_ma__0B91BA14");

                    b.Navigation("IdFichaTecnicaNavigation");

                    b.Navigation("IdMaterialNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetalleOc", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.Material", "IdMaterialNavigation")
                        .WithMany("DetalleOcs")
                        .HasForeignKey("IdMaterial")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_O__id_ma__5DCAEF64");

                    b.HasOne("MakiYumpuSAC.Models.OrdenCompra", "IdOcmNavigation")
                        .WithMany("DetalleOcs")
                        .HasForeignKey("IdOcm")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_O__id_oc__5EBF139D");

                    b.Navigation("IdMaterialNavigation");

                    b.Navigation("IdOcmNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.DetallePedido", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.FichaTecnica", "IdFichaTecnicaNavigation")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("IdFichaTecnica")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_P__id_fi__06CD04F7");

                    b.HasOne("MakiYumpuSAC.Models.Pedido", "IdPedidoNavigation")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("IdPedido")
                        .IsRequired()
                        .HasConstraintName("FK__DETALLE_P__id_pe__07C12930");

                    b.Navigation("IdFichaTecnicaNavigation");

                    b.Navigation("IdPedidoNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.ImgFichaTecnica", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.FichaTecnica", "IdFichaTecnicaNavigation")
                        .WithMany("ImgFichaTecnicas")
                        .HasForeignKey("IdFichaTecnica")
                        .IsRequired()
                        .HasConstraintName("FK__IMG_FICHA__id_fi__0E6E26BF");

                    b.Navigation("IdFichaTecnicaNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.ImgFormPedido", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.FormPedido", "IdFormPedidoNavigation")
                        .WithMany("ImgFormPedidos")
                        .HasForeignKey("IdFormPedido")
                        .IsRequired()
                        .HasConstraintName("FK__IMG_FORM___id_fo__03F0984C");

                    b.Navigation("IdFormPedidoNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Material", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.MaterialBase", "IdMaterialBaseNavigation")
                        .WithMany("Materials")
                        .HasForeignKey("IdMaterialBase")
                        .IsRequired()
                        .HasConstraintName("FK__MATERIAL__id_mat__403A8C7D");

                    b.Navigation("IdMaterialBaseNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Pedido", b =>
                {
                    b.HasOne("MakiYumpuSAC.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("FK__PEDIDO__id_clien__46E78A0C");

                    b.HasOne("MakiYumpuSAC.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdUsuario")
                        .IsRequired()
                        .HasConstraintName("FK__PEDIDO__id_usuar__47DBAE45");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.FichaTecnica", b =>
                {
                    b.Navigation("DetalleFts");

                    b.Navigation("DetallePedidos");

                    b.Navigation("ImgFichaTecnicas");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.FormPedido", b =>
                {
                    b.Navigation("DetalleFormPedidos");

                    b.Navigation("ImgFormPedidos");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Material", b =>
                {
                    b.Navigation("DetalleFts");

                    b.Navigation("DetalleOcs");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.MaterialBase", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.OrdenCompra", b =>
                {
                    b.Navigation("DetalleOcs");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Pedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("MakiYumpuSAC.Models.Usuario", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
