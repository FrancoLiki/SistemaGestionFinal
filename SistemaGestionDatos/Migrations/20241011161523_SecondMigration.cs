using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionDatos.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdVenta",
                table: "ProductosVendidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVenta",
                table: "ProductosVendidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
