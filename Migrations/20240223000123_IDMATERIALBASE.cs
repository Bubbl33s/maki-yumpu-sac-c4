using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakiYumpuSAC.Migrations
{
    /// <inheritdoc />
    public partial class IDMATERIALBASE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Eliminar la relación entre las tablas MATERIAL y MATERIAL_BASE
            migrationBuilder.DropForeignKey(
                name: "FK__MATERIAL__id_mat__403A8C7D",
                table: "MATERIAL");

            // 2. Modificar la tabla MATERIAL_BASE para que id_material_base sea una clave primaria
            migrationBuilder.DropPrimaryKey(
                name: "PK__MATERIAL__AB78780E1706B4D7",
                table: "MATERIAL_BASE");

            migrationBuilder.DropColumn(
                name: "id_material_base",
                table: "MATERIAL_BASE");

            migrationBuilder.AddColumn<int>(
                name: "id_material_base",
                table: "MATERIAL_BASE",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MATERIAL_BASE",
                table: "MATERIAL_BASE",
                column: "id_material_base");

            // 3. Agregar la nueva columna codigo_material a la tabla MATERIAL_BASE
            migrationBuilder.AddColumn<string>(
                name: "codigo_material",
                table: "MATERIAL_BASE",
                type: "varchar(20)",
                nullable: true);

            // 4. Modificar el tipo de columna id_material_base en la tabla MATERIAL de varchar a int
            migrationBuilder.AlterColumn<int>(
                name: "id_material_base",
                table: "MATERIAL",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            // 5. Agregar la relación nuevamente entre las tablas MATERIAL y MATERIAL_BASE
            migrationBuilder.AddForeignKey(
                name: "FK_MATERIAL_MATERIAL_BASE_id_material_base",
                table: "MATERIAL",
                column: "id_material_base",
                principalTable: "MATERIAL_BASE",
                principalColumn: "id_material_base",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "UQ__MATERIAL__B586E7C0C0D9F1D6",
                table: "MATERIAL",
                columns: new[] { "id_material_base", "id_pantone", "hebras" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
