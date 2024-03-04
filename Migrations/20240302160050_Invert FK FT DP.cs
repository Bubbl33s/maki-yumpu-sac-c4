using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakiYumpuSAC.Migrations
{
    /// <inheritdoc />
    public partial class InvertFKFTDP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__DETALLE_P__id_fi__06CD04F7",
                table: "DETALLE_PEDIDO");

            migrationBuilder.DropColumn(
                name: "id_ficha_tecnica",
                table: "DETALLE_PEDIDO");

            migrationBuilder.AddColumn<int>(
                name: "id_detalle_pedido",
                table: "FICHA_TECNICA",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_FICHA_TECNICA_DETALLE_PEDIDO",
                table: "FICHA_TECNICA",
                column: "id_detalle_pedido",
                principalTable: "DETALLE_PEDIDO",
                principalColumn: "id_det_pedido",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FICHA_TECNICA_DETALLE_PEDIDO",
                table: "FICHA_TECNICA");

            migrationBuilder.DropColumn(
                name: "id_detalle_pedido",
                table: "FICHA_TECNICA");

            migrationBuilder.AddColumn<int>(
                name: "id_ficha_tecnica",
                table: "DETALLE_PEDIDO",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK__DETALLE_P__id_fi__06CD04F7",
                table: "DETALLE_PEDIDO",
                column: "id_ficha_tecnica",
                principalTable: "FICHA_TECNICA",
                principalColumn: "id_ficha_tecnica",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
