using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class todasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantDisp = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    TipoSensor = table.Column<int>(type: "int", nullable: true),
                    Resolution = table.Column<int>(type: "int", nullable: true),
                    PixelSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    CargaKG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GoTo = table.Column<bool>(type: "bit", nullable: true),
                    Diametro = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GradosVision = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Apertura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RelacionFocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanciaFocal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PesoKG = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observaciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Observaciones");
        }
    }
}
