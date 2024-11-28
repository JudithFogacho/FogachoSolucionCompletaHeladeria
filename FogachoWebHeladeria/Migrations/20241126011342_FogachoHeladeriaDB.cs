using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FogachoWebHeladeria.Migrations
{
    /// <inheritdoc />
    public partial class FogachoHeladeriaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AF_Helado",
                columns: table => new
                {
                    AF_IdHeladeria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AF_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AF_Sabor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AF_Categorias = table.Column<int>(type: "int", nullable: false),
                    AF_Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AF_Queso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AF_Helado", x => x.AF_IdHeladeria);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AF_Helado");
        }
    }
}
