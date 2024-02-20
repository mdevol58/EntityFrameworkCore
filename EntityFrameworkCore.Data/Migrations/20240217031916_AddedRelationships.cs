using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Coaches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamScore",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamScore",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jose Mourinio" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop Guardiola" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trevoir Williams" }
                });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId" },
                values: new object[] { 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId" },
                values: new object[] { 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId" },
                values: new object[] { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Coaches_CoachId",
                table: "Teams",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_AwayTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_HomeTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Coaches_CoachId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CoachId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Name",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches");

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AwayTeamScore",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamScore",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                columns: new[] { "CoachId", "CreatedDate", "LeagueId" },
                values: new object[] { 0, new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(9467), 0 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId" },
                values: new object[] { 0, new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(9469), 0 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoachId", "CreatedDate", "LeagueId" },
                values: new object[] { 0, new DateTime(2024, 2, 16, 18, 57, 0, 240, DateTimeKind.Utc).AddTicks(9470), 0 });
        }
    }
}
