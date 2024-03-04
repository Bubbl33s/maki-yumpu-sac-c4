using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakiYumpuSAC.Migrations
{
    /// <inheritdoc />
    public partial class uniques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Restricción única en la columna nombre_completo_cliente de la tabla CLIENTE
            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_nombre_completo_cliente",
                table: "CLIENTE",
                column: "nombre_completo_cliente",
                unique: true);

            // Restricción única en la columna correo_cliente de la tabla CLIENTE
            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_correo_cliente",
                table: "CLIENTE",
                column: "correo_cliente",
                unique: true);

            // Restricción única en la combinación de tres columnas para USUARIO
            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ap_pat_usuario_ap_mat_usuario_nombres_usuario",
                table: "USUARIO",
                columns: new[] { "ap_pat_usuario", "ap_mat_usuario", "nombres_usuario" },
                unique: true);

            // Restricción única en la columna login_usuario de la tabla USUARIO
            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_login_usuario",
                table: "USUARIO",
                column: "login_usuario",
                unique: true);

            // Restricción única en la columna dni_usuario de la tabla USUARIO
            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_dni_usuario",
                table: "USUARIO",
                column: "dni_usuario",
                unique: true);

            // Restricción única en la columna codigo_material de la tabla MATERIAL_BASE
            migrationBuilder.CreateIndex(
                name: "IX_MATERIAL_BASE_codigo_material",
                table: "MATERIAL_BASE",
                column: "codigo_material",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
