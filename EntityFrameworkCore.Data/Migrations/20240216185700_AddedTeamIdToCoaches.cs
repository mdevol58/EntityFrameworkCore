using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeamIdToCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Coaches",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(9470));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Coaches");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 1, 29, 867, DateTimeKind.Utc).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 1, 29, 867, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 18, 1, 29, 867, DateTimeKind.Utc).AddTicks(9461));

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
    }
}
