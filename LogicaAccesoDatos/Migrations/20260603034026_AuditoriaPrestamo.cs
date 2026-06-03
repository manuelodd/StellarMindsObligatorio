using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_SocioId",
                table: "Prestamos");

            migrationBuilder.CreateTable(
                name: "AuditoriaPrestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaPrestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaPrestamo_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditoriaPrestamo_Usuarios_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaPrestamo_CoordinadorId",
                table: "AuditoriaPrestamo",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaPrestamo_PrestamoId",
                table: "AuditoriaPrestamo",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_SocioId",
                table: "Prestamos",
                column: "SocioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_SocioId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "AuditoriaPrestamo");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_SocioId",
                table: "Prestamos",
                column: "SocioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
