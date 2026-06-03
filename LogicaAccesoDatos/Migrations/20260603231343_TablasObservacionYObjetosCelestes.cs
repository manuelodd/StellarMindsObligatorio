using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TablasObservacionYObjetosCelestes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Observaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Indicador",
                table: "Observaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ObjetoCelesteId",
                table: "Observaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrestamoId",
                table: "Observaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ObjetosCelestes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    MagnitudAparente = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_ObjetoCelesteId",
                table: "Observaciones",
                column: "ObjetoCelesteId");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_PrestamoId",
                table: "Observaciones",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observaciones_ObjetosCelestes_ObjetoCelesteId",
                table: "Observaciones",
                column: "ObjetoCelesteId",
                principalTable: "ObjetosCelestes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observaciones_Prestamos_PrestamoId",
                table: "Observaciones",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observaciones_ObjetosCelestes_ObjetoCelesteId",
                table: "Observaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Observaciones_Prestamos_PrestamoId",
                table: "Observaciones");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");

            migrationBuilder.DropIndex(
                name: "IX_Observaciones_ObjetoCelesteId",
                table: "Observaciones");

            migrationBuilder.DropIndex(
                name: "IX_Observaciones_PrestamoId",
                table: "Observaciones");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Observaciones");

            migrationBuilder.DropColumn(
                name: "Indicador",
                table: "Observaciones");

            migrationBuilder.DropColumn(
                name: "ObjetoCelesteId",
                table: "Observaciones");

            migrationBuilder.DropColumn(
                name: "PrestamoId",
                table: "Observaciones");
        }
    }
}
