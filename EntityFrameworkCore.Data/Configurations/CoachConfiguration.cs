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
    internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(new Coach
            {
                                Id = 1,
                                Name = "Jose Mourinio"
                            },
                            new Coach
                            {
                                Id = 2,
                                Name = "Pop Guardiola"
                            },
                            new Coach
                            {
                                Id = 3,
                                Name = "Trevoir Williams"
                            });
        }
    }
}
