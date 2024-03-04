using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakiYumpuSAC.Migrations
{
    /// <inheritdoc />
    public partial class cardexid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado_pedido_id",
                table: "PEDIDO",
                newName: "estado_pedido");

            migrationBuilder.AlterColumn<string>(
                name: "estado_pedido",
                table: "PEDIDO",
                type: "VARCHAR(15)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "PEDIDO",
                nullable: false,
                defaultValue: true);

            migrationBuilder.DropPrimaryKey(
                name: "PK__CARDEX_MATERIAL",
                table: "CARDEX_MATERIAL");

            migrationBuilder.AddColumn<int>(
                name: "id_detalle_cardex",
                table: "CARDEX_MATERIAL",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARDEX_MATERIAL",
                table: "CARDEX_MATERIAL",
                column: "id_detalle_cardex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
