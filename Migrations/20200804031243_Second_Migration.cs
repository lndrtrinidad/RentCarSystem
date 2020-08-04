using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarSystem.Migrations
{
    public partial class Second_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "FechaCreacion", "NombreUsuario", "Nombres", "Password" },
                values: new object[] { 1, new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "Leandro Trinidad", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);
        }
    }
}
