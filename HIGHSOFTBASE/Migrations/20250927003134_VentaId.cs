using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIGHSOFTBASE.Migrations
{
    /// <inheritdoc />
    public partial class VentaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ventas",
                newName: "VentaId");

            migrationBuilder.AlterColumn<string>(
                name: "Servicio",
                table: "Ventas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "Ventas",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Servicio",
                table: "Ventas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
