using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using EntityFrameworkCore.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasIndex(team => team.Name).IsUnique();

            builder.HasMany(team => team.HomeMatches)
                   .WithOne(match => match.HomeTeam)
                   .HasForeignKey(match => match.HomeTeamId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(team => team.AwayMatches)
                   .WithOne(match => match.AwayTeam)
                   .HasForeignKey(match => match.AwayTeamId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Team
                            {
                                Id = 1,
                                Name = "Tivoli Gardens F.C.",
                                CreatedDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc),
                                LeagueId = 1,
                                CoachId = 1,
                            },
                            new Team
                            {
                                Id = 2,
                                Name = "Waterhouse F.C.",
                                CreatedDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc),
                                LeagueId = 1,
                                CoachId = 2,
                            },
                            new Team
                            {
                                Id = 3,
                                Name = "Humble Lions F.C.",
                                CreatedDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc),
                                LeagueId = 1,
                                CoachId = 3,
                            }
                           );
        }
    }
}
