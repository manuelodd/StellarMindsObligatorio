using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Prestamos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CamaraId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonturaId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OcularId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelescopioId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CamaraId",
                table: "Prestamos",
                column: "CamaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MonturaId",
                table: "Prestamos",
                column: "MonturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OcularId",
                table: "Prestamos",
                column: "OcularId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_TelescopioId",
                table: "Prestamos",
                column: "TelescopioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Equipos_CamaraId",
                table: "Prestamos",
                column: "CamaraId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Equipos_MonturaId",
                table: "Prestamos",
                column: "MonturaId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Equipos_OcularId",
                table: "Prestamos",
                column: "OcularId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Equipos_TelescopioId",
                table: "Prestamos",
                column: "TelescopioId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Equipos_CamaraId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Equipos_MonturaId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Equipos_OcularId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Equipos_TelescopioId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_CamaraId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_MonturaId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_OcularId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_TelescopioId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "CamaraId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "MonturaId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "OcularId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "TelescopioId",
                table: "Prestamos");
        }
    }
}
