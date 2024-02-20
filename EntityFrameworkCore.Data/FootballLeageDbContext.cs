using System.Reflection;

using EntityFrameworkCore.Data.Configurations;
using EntityFrameworkCore.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
    public class FootballLeageDbContext : DbContext
    {
        public DbSet<Team> Teams
        {
            get;
            set;
        }

        public DbSet<Coach> Coaches
        {
            get;
            set;
        }

        public DbSet<League> Leagues
        {
            get;
            set;
        }

        public DbSet<Match> Matches
        {
            get;
            set;
        }

        public DbSet<TeamsAndLeaguesView> TeamsAndLeaguesViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VOYAGER\\Voyager22; Initial Catalog=FootballLeage_EFCore; Integrated Security=true; TrustServerCertificate=true;")
                          .UseLazyLoadingProxies()    // used for Lazy Loading, not recomended
                          //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                          .LogTo(Console.WriteLine, LogLevel.Information)
                          .EnableSensitiveDataLogging()
                          .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<TeamsAndLeaguesView>()
                        .HasNoKey()
                        .ToView("vw_TeamsAndLeagues");
            modelBuilder.HasDbFunction(typeof(FootballLeageDbContext).GetMethod(nameof(GetEarliestTeamMatch), new[] { typeof(int) }))
                        .HasName("GetEarliestMatch");
        }

//        [DbFunction("GetEarliestMatch", "dbo")]
        public DateTime GetEarliestTeamMatch(int teamId) => throw new NotImplementedException();
    }
}
