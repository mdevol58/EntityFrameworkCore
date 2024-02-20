using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFrameworkCore.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasData(new League
                            {
                                Id = 1,
                                Name = "Jamica Premiere League",
                                CreatedDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc)
                            },
                            new League
                            {
                                Id = 2,
                                Name = "English Premiere League",
                                CreatedDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc)
                            },
                            new League
                            {
                                Id = 3,
                                Name = "La Liga",
                                CreatedDate = new DateTime(2023, 09, 01, 0, 0, 0, DateTimeKind.Utc)
                            });
        }
    }
}
