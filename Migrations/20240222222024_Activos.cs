using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakiYumpuSAC.Migrations
{
    /// <inheritdoc />
    public partial class Activos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "CLIENTE",
                nullable: false,
                defaultValue: true
                );

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "USUARIO",
                nullable: false,
                defaultValue: true
                );

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "MATERIAL",
                nullable: false,
                defaultValue: true
                );

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "MATERIAL_BASE",
                nullable: false,
                defaultValue: true
                );

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "FICHA_TECNICA",
                nullable: false,
                defaultValue: true
                );

            /*
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_completo_cliente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    correo_cliente = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    pais_cliente = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENTE__677F38F51656479A", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "FICHA_TECNICA",
                columns: table => new
                {
                    id_ficha_tecnica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_prenda = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fecha_ft = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    otros_materiales_desc = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    peso_prenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    talla_prenda = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    tejido_desc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    armado_desc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    acabados_desc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    vaporizado_desc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FICHA_TE__96E2E4B326E4E279", x => x.id_ficha_tecnica);
                });

            migrationBuilder.CreateTable(
                name: "FORM_PEDIDO",
                columns: table => new
                {
                    id_form_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_completo_cliente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    correo_cliente = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    pais_cliente = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FORM_PED__CD6CC369E97A6EF5", x => x.id_form_pedido);
                });

            migrationBuilder.CreateTable(
                name: "MATERIAL_BASE",
                columns: table => new
                {
                    id_material_base = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    desc_material = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MATERIAL__AB78780E1706B4D7", x => x.id_material_base);
                });

            migrationBuilder.CreateTable(
                name: "ORDEN_COMPRA",
                columns: table => new
                {
                    id_ocm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_oc = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado_oc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ORDEN_CO__6E0ED9CA1C242ADE", x => x.id_ocm);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ap_pat_usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ap_mat_usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nombres_usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    dni_usuario = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    login_usuario = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    password_usuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fecha_nac_usuario = table.Column<DateTime>(type: "datetime", nullable: false),
                    es_admin = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__4E3E04AD6D6362D2", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "IMG_FICHA_TECNICA",
                columns: table => new
                {
                    id_img_ft = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ficha_tecnica = table.Column<int>(type: "int", nullable: false),
                    ruta_imagen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IMG_FICH__4687A08F2A29530E", x => x.id_img_ft);
                    table.ForeignKey(
                        name: "FK__IMG_FICHA__id_fi__0E6E26BF",
                        column: x => x.id_ficha_tecnica,
                        principalTable: "FICHA_TECNICA",
                        principalColumn: "id_ficha_tecnica");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_FORM_PEDIDO",
                columns: table => new
                {
                    id_det_form_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_form_pedido = table.Column<int>(type: "int", nullable: false),
                    desc_prenda = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    detalles_prenda = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    cantidad_prenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___B60583E52DE61B18", x => x.id_det_form_pedido);
                    table.ForeignKey(
                        name: "FK__DETALLE_F__id_fo__5629CD9C",
                        column: x => x.id_form_pedido,
                        principalTable: "FORM_PEDIDO",
                        principalColumn: "id_form_pedido");
                });

            migrationBuilder.CreateTable(
                name: "IMG_FORM_PEDIDO",
                columns: table => new
                {
                    id_img_form_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_form_pedido = table.Column<int>(type: "int", nullable: false),
                    ruta_imagen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IMG_FORM__79674D65AD108725", x => x.id_img_form_pedido);
                    table.ForeignKey(
                        name: "FK__IMG_FORM___id_fo__03F0984C",
                        column: x => x.id_form_pedido,
                        principalTable: "FORM_PEDIDO",
                        principalColumn: "id_form_pedido");
                });

            migrationBuilder.CreateTable(
                name: "MATERIAL",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_material_base = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    id_pantone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    hebras = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MATERIAL__81E99B83F6862540", x => x.id_material);
                    table.ForeignKey(
                        name: "FK__MATERIAL__id_mat__403A8C7D",
                        column: x => x.id_material_base,
                        principalTable: "MATERIAL_BASE",
                        principalColumn: "id_material_base");
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_generacion_pedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_entrega = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    estado_pedido_id = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PEDIDO__6FF01489C9DB689D", x => x.id_pedido);
                    table.ForeignKey(
                        name: "FK__PEDIDO__id_clien__46E78A0C",
                        column: x => x.id_cliente,
                        principalTable: "CLIENTE",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "FK__PEDIDO__id_usuar__47DBAE45",
                        column: x => x.id_usuario,
                        principalTable: "USUARIO",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "CARDEX_MATERIAL",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    cantidad = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    stock = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    conos = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CARDEX_MATERIAL", x => x.id_material);
                    table.ForeignKey(
                        name: "FK__CARDEX_MA__id_ma__4316F928",
                        column: x => x.id_material,
                        principalTable: "MATERIAL",
                        principalColumn: "id_material");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_FT",
                columns: table => new
                {
                    id_det_ft = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ficha_tecnica = table.Column<int>(type: "int", nullable: false),
                    id_material = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___E90F8F3888F791AB", x => x.id_det_ft);
                    table.ForeignKey(
                        name: "FK__DETALLE_F__id_fi__0A9D95DB",
                        column: x => x.id_ficha_tecnica,
                        principalTable: "FICHA_TECNICA",
                        principalColumn: "id_ficha_tecnica");
                    table.ForeignKey(
                        name: "FK__DETALLE_F__id_ma__0B91BA14",
                        column: x => x.id_material,
                        principalTable: "MATERIAL",
                        principalColumn: "id_material");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_OC",
                columns: table => new
                {
                    id_ocm = table.Column<int>(type: "int", nullable: false),
                    id_material = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___3709761F1A3C0C46", x => new { x.id_material, x.id_ocm });
                    table.ForeignKey(
                        name: "FK__DETALLE_O__id_ma__5DCAEF64",
                        column: x => x.id_material,
                        principalTable: "MATERIAL",
                        principalColumn: "id_material");
                    table.ForeignKey(
                        name: "FK__DETALLE_O__id_oc__5EBF139D",
                        column: x => x.id_ocm,
                        principalTable: "ORDEN_COMPRA",
                        principalColumn: "id_ocm");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_PEDIDO",
                columns: table => new
                {
                    id_det_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    id_ficha_tecnica = table.Column<int>(type: "int", nullable: false),
                    cantidad_prenda = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___3D43846198A6AEE5", x => x.id_det_pedido);
                    table.ForeignKey(
                        name: "FK__DETALLE_P__id_fi__06CD04F7",
                        column: x => x.id_ficha_tecnica,
                        principalTable: "FICHA_TECNICA",
                        principalColumn: "id_ficha_tecnica");
                    table.ForeignKey(
                        name: "FK__DETALLE_P__id_pe__07C12930",
                        column: x => x.id_pedido,
                        principalTable: "PEDIDO",
                        principalColumn: "id_pedido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_FORM_PEDIDO_id_form_pedido",
                table: "DETALLE_FORM_PEDIDO",
                column: "id_form_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_FT_id_ficha_tecnica",
                table: "DETALLE_FT",
                column: "id_ficha_tecnica");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_FT_id_material",
                table: "DETALLE_FT",
                column: "id_material");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_OC_id_ocm",
                table: "DETALLE_OC",
                column: "id_ocm");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_PEDIDO_id_ficha_tecnica",
                table: "DETALLE_PEDIDO",
                column: "id_ficha_tecnica");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_PEDIDO_id_pedido",
                table: "DETALLE_PEDIDO",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_IMG_FICHA_TECNICA_id_ficha_tecnica",
                table: "IMG_FICHA_TECNICA",
                column: "id_ficha_tecnica");

            migrationBuilder.CreateIndex(
                name: "IX_IMG_FORM_PEDIDO_id_form_pedido",
                table: "IMG_FORM_PEDIDO",
                column: "id_form_pedido");

            migrationBuilder.CreateIndex(
                name: "UQ__MATERIAL__B586E7C0C0D9F1D6",
                table: "MATERIAL",
                columns: new[] { "id_material_base", "id_pantone", "hebras" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_id_cliente",
                table: "PEDIDO",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_id_usuario",
                table: "PEDIDO",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "UQ__USUARIO__B68C02517C4CCB72",
                table: "USUARIO",
                column: "dni_usuario",
                unique: true);
            */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARDEX_MATERIAL");

            migrationBuilder.DropTable(
                name: "DETALLE_FORM_PEDIDO");

            migrationBuilder.DropTable(
                name: "DETALLE_FT");

            migrationBuilder.DropTable(
                name: "DETALLE_OC");

            migrationBuilder.DropTable(
                name: "DETALLE_PEDIDO");

            migrationBuilder.DropTable(
                name: "IMG_FICHA_TECNICA");

            migrationBuilder.DropTable(
                name: "IMG_FORM_PEDIDO");

            migrationBuilder.DropTable(
                name: "MATERIAL");

            migrationBuilder.DropTable(
                name: "ORDEN_COMPRA");

            migrationBuilder.DropTable(
                name: "PEDIDO");

            migrationBuilder.DropTable(
                name: "FICHA_TECNICA");

            migrationBuilder.DropTable(
                name: "FORM_PEDIDO");

            migrationBuilder.DropTable(
                name: "MATERIAL_BASE");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
