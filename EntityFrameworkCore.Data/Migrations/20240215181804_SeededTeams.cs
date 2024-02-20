using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 15, 18, 18, 4, 451, DateTimeKind.Utc).AddTicks(4444), "Tivoli Gardens F.C." },
                    { 2, new DateTime(2024, 2, 15, 18, 18, 4, 451, DateTimeKind.Utc).AddTicks(4446), "Waterhouse F.C." },
                    { 3, new DateTime(2024, 2, 15, 18, 18, 4, 451, DateTimeKind.Utc).AddTicks(4447), "Humble Lions F.C." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
