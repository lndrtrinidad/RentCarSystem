using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarSystem.Migrations
{
    public partial class Third_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Descripcion" },
                values: new object[] { 1, "Mercedez Benz" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Descripcion" },
                values: new object[] { 2, "Toyota" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Descripcion" },
                values: new object[] { 3, "Honda" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "MarcaId", "Descripcion" },
                values: new object[] { 4, "Lexus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "MarcaId",
                keyValue: 4);
        }
    }
}
