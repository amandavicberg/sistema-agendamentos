using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAgendamentos.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixUsuarioSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 17, 17, 59, 25, 285, DateTimeKind.Utc).AddTicks(2610), "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 17, 17, 18, 17, 202, DateTimeKind.Utc).AddTicks(7160), "$2a$11$fQLVxWC9GkWvq7MM/jnzm.0OptTkZNGwuKiToNH.xhnZkTXuTLu42" });
        }
    }
}
