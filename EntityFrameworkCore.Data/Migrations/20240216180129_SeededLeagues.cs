using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededLeagues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 16, 18, 1, 29, 867, DateTimeKind.Utc).AddTicks(9456), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamica Premiere League" },
                    { 2, null, new DateTime(2024, 2, 16, 18, 1, 29, 867, DateTimeKind.Utc).AddTicks(9459), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "English Premiere League" },
                    { 3, null, new DateTime(2024, 2, 16, 18, 1, 29, 867, DateTimeKind.Utc).AddTicks(9461), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "La Liga" }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 1, 29, 868, DateTimeKind.Utc).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 1, 29, 868, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 1, 29, 868, DateTimeKind.Utc).AddTicks(1015));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 17, 14, 27, 358, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 17, 14, 27, 358, DateTimeKind.Utc).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 17, 14, 27, 358, DateTimeKind.Utc).AddTicks(5963));
        }
    }
}
