using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIGHSOFTBASE.Migrations
{
    /// <inheritdoc />
    public partial class AddServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: true),
                    CategoriaServicioId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_CategoriaServicios_CategoriaServicioId",
                        column: x => x.CategoriaServicioId,
                        principalTable: "CategoriaServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaServicios_Nombre",
                table: "CategoriaServicios",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_CategoriaServicioId",
                table: "Servicios",
                column: "CategoriaServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaServicios_Nombre",
                table: "CategoriaServicios");
        }
    }
}
