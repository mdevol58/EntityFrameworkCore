using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTeamLeagueAndCoachesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create view vw_TeamsAndLeagues
                as
                select t.Name, l.Name as LeagueName
                from Teams as T left join
                     Leagues as l on t.LeagueId = l.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view vw_TeamsAndLeagues");
        }
    }
}
