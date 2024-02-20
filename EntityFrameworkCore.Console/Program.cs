using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (FootballLeageDbContext context = new FootballLeageDbContext())
            {
                //await context.Database.MigrateAsync();

                //await GetAllTeams(context);

                //await GetOneTeam(context);
                //GetFilteredTeams(context);
                //GetAllTeamsQuerySyntax(context);
                //await AggarateMethods(context);
                //GroupByMethod(context);
                //OrderByMethod(context);
                //await SkipAndTake(context);
                //await ProjectionAndSelect(context);
                //await NoTracking(context);
                //await ListVsQueryable(context);
                //await InsertDataRecord(context);
                //await UpdateWithTracking(context);
                //await UpdateNoTracking(context);
                //await DeleteRecord(context);
                //await ExecuteDelete(context);
                //await ExecuteUpdate(context);
                //await InsertRecordWithFK(context);
                //await InsertParentChild(context);
                //await InsertParentWIthChildren(context);
                //await EagerLoading(context);
                //await ExplicitLoading(context);
                await LazyLoading(context);
                //await InsertMoreMatches(context);
                //await FilteringInclude(context);
                //await AnonymousTypeAndRelatedData(context);
                //await QueryingKeylessEntityOrView(context);
                //UsingRawSql(context);
                //UsingRawSqlWithLinq(context);
                //CallingStoredProcedure(context);
                //ScalarQuery(context);
                //CallingUserDefinedFunction(context);

            }
        }

        private static void CallingUserDefinedFunction(FootballLeageDbContext context)
        {
            var earliestMatch = context.Matches.FirstOrDefault(match => match.Date == context.GetEarliestTeamMatch(1));
        }

        private static void ScalarQuery(FootballLeageDbContext context)
        {
            var leagueIds = context.Database.SqlQuery<int>($"select id from leagues").ToList();
        }

        private static void CallingStoredProcedure(FootballLeageDbContext context)
        {
            var leagueId = 1;
            var league = context.Leagues
                                .FromSqlInterpolated($"exec GetLeagueName {leagueId}")
                                .ToList();

            // Some additional examples

            //var someNewTeam = "New Team Name Here";
            //var success = context.Database.ExecuteSqlInterpolated($"update Teams set name = {someNewTeam}");

            //var teamToDeleteId = 1;
            //var teamDeletedSuccess = context.Database.ExecuteSqlInterpolated($"exec DeleteTeam {teamToDeleteId}");
        }

        private static void UsingRawSqlWithLinq(FootballLeageDbContext context)
        {
            System.Console.Write("Enter team name: ");

            var teamName = System.Console.ReadLine();
            var teams = context.Teams.FromSql($"select * from Teams")
                                     .Where(team => team.Id == 1)
                                     .OrderBy(team => team.Id)
                                     .Include("League")
                                     .ToList();

            foreach (var team in teams)
            {
                System.Console.WriteLine(team);
            }
        }

        private static void UsingRawSql(FootballLeageDbContext context)
        {
            System.Console.Write("Enter team name: ");

            var teamName = System.Console.ReadLine();
            var teamNameParam = new SqlParameter("teamName", teamName);
            var teams = context.Teams.FromSqlRaw($"select * from Teams where name = @teamName", teamNameParam);

            foreach (var team in teams)
            {
                System.Console.WriteLine(team);
            }

            teams = context.Teams.FromSql($"select * from Teams where name = {teamName}");

            foreach (var team in teams)
            {
                System.Console.WriteLine(team);
            }

            teams = context.Teams.FromSqlInterpolated($"select * from Teams where name = {teamName}");

            foreach (var team in teams)
            {
                System.Console.WriteLine(team);
            }
        }

        private static async Task QueryingKeylessEntityOrView(FootballLeageDbContext context)
        {
            var details = await context.TeamsAndLeaguesViews.ToListAsync();
        }

        private static async Task AnonymousTypeAndRelatedData(FootballLeageDbContext context)
        {
            var teams = await context.Teams
                                     .Select(team => new TeamDetails
                                     {
                                         TeamId = team.Id,
                                         TeamName = team.Name,
                                         CoachName = team.Coach.Name,
                                         TotalHomeGoals = team.HomeMatches.Sum(match => match.HomeTeamScore),
                                         TotalAwayGoals = team.AwayMatches.Sum(match => match.AwayTeamScore)
                                     })
                                     .ToListAsync();

            foreach (var team in teams)
            {
                System.Console.WriteLine($"{team.TeamName} - {team.CoachName} | Home Goals: {team.TotalHomeGoals} | Away Goals: {team.TotalAwayGoals}");
            }
        }

        private static async Task FilteringInclude(FootballLeageDbContext context)
        {

            // Filtering Include
            // Get all teams and only home matches where they have scored

            var teams = await context.Teams
                                     .Include("Coach")
                                     .Include(team => team.HomeMatches
                                                          .Where(match => match.HomeTeamScore > 0))
                                     .ToListAsync();

            foreach (var team in teams)
            {
                System.Console.WriteLine($"{team.Name} - {team.Coach.Name}");

                foreach (var match in team.HomeMatches)
                {
                    System.Console.WriteLine($"\tScore {match.HomeTeamScore}");
                }
            }
        }

        private static async Task InsertMoreMatches(FootballLeageDbContext context)
        {
            var match1 = new Match
            {
                AwayTeamId = 2,
                HomeTeamId = 3,
                HomeTeamScore = 1,
                AwayTeamScore = 0,
                Date = new DateTime(2023, 1, 1),
                TicketPrice = 20M
            };
            var match2 = new Match
            {
                AwayTeamId = 2,
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamScore = 0,
                Date = new DateTime(2023, 1, 1),
                TicketPrice = 20M
            };
            var match3 = new Match
            {
                AwayTeamId = 1,
                HomeTeamId = 3,
                HomeTeamScore = 1,
                AwayTeamScore = 0,
                Date = new DateTime(2023, 1, 1),
                TicketPrice = 20M
            };
            var match4 = new Match
            {
                AwayTeamId = 4,
                HomeTeamId = 3,
                HomeTeamScore = 0,
                AwayTeamScore = 1,
                Date = new DateTime(2023, 1, 1),
                TicketPrice = 20M
            };

            await context.AddRangeAsync(match1, match2, match3, match4);
            await context.SaveChangesAsync();
        }

        private static async Task LazyLoading(FootballLeageDbContext context)
        {
            // Example 1
            var league = await context.FindAsync<League>(1);

            foreach (var team in league.Teams)
            {
                System.Console.WriteLine($"{team.Name}");
            }

            // Example 2

            foreach (var league1 in context.Leagues)
            {
                foreach (var team in league1.Teams)
                {
                    System.Console.WriteLine($"{team.Name} - {team.Coach.Name}");
                }
            }
        }

        private static async Task ExplicitLoading(FootballLeageDbContext context)
        {
            var league = await context.FindAsync<League>(1);

            if (!league.Teams.Any())
            {
                System.Console.WriteLine("Teams have not been loaded");
            }

            await context.Entry(league)
                         .Collection(league => league.Teams)
                         .LoadAsync();

            if (league.Teams.Any())
            {
                foreach (var team in league.Teams)
                {
                    System.Console.WriteLine($"\t{team.Name}");
                }
            }
        }

        private static async Task EagerLoading(FootballLeageDbContext context)
        {
            var leagues = await context.Leagues
                                       .Include(league => league.Teams)
                                       .ThenInclude(team => team.Coach)
                                       .ToListAsync();

            foreach (var league in leagues)
            {
                System.Console.WriteLine($"League: {league.Name}");

                foreach (var team in league.Teams)
                {
                    System.Console.WriteLine($"\t{team.Name} - {team.Coach.Name}");
                }
            }
        }

        private static async Task InsertRecordWithFK(FootballLeageDbContext context)
        {
            var match = new Match()
            {
                AwayTeamId = 1,
                HomeTeamId = 2,
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Date = new DateTime(2024, 10, 1),
                TicketPrice = 20.0M
            };

            await context.AddAsync(match);
            await context.SaveChangesAsync();

            // This will fail with bad FK

            var match1 = new Match()
            {
                AwayTeamId = 10,
                HomeTeamId = 0,
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Date = new DateTime(2024, 10, 1),
                TicketPrice = 20.0M
            };

            await context.AddAsync(match1);
            await context.SaveChangesAsync();
        }

        private static async Task InsertParentChild(FootballLeageDbContext context)
        {
            var team = new Team()
            {
                Name = "New Team",
                Coach = new Coach()
                {
                    Name = "Johnson"
                }
            };

            await context.AddAsync(team);
            await context.SaveChangesAsync();
        }

        private static async Task InsertParentWIthChildren(FootballLeageDbContext context)
        {
            var league = new League()
            {
                Name = "Serie A",
                Teams = new List<Team>
                    {
                        new Team()
                        {
                            Name = "Juventus",
                            Coach = new Coach()
                            {
                                Name = "Juve Coach"
                            }
                        },
                        new Team()
                        {
                            Name = "AC Milan",
                            Coach = new Coach()
                            {
                                Name = "Milan Coach"
                            }
                        },
                        new Team()
                        {
                            Name = "AS Roma",
                            Coach = new Coach()
                            {
                                Name = "Roma Coach"
                            }
                        }
                    }
            };

            await context.AddAsync(league);
            await context.SaveChangesAsync();
        }

        private static async Task ExecuteDelete(FootballLeageDbContext context)
        {
            await context.Coaches.Where(coach => coach.Name == "Theodore Whitmore").ExecuteDeleteAsync();
        }

        private static async Task ExecuteUpdate(FootballLeageDbContext context)
        {
            await context.Coaches.Where(coach => coach.Name == "Jose Mourino").ExecuteUpdateAsync(set => set.SetProperty(prop => prop.Name, "Pop Gourdiola")
                                                                                                            .SetProperty(prop => prop.CreatedDate, DateTime.UtcNow));
        }

        private static async Task DeleteRecord(FootballLeageDbContext context)
        {
            var coach = await context.Coaches.FindAsync(5);

            context.Remove(coach);
            context.SaveChanges();
        }

        private static async Task UpdateNoTracking(FootballLeageDbContext context)
        {
            var coach1 = await context.Coaches
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(coach => coach.Id == 4);

            coach1.Name = "Testing no tracking behavior";

            System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);

            //context.Update(coach1);
            context.Entry(coach1).State = EntityState.Modified;

            System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);

            await context.SaveChangesAsync();

            System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        }

        private static async Task UpdateWithTracking(FootballLeageDbContext context)
        {
            var coach = await context.Coaches.FindAsync(5);

            coach.Name = "Treovir Williams";
            coach.CreatedDate = DateTime.UtcNow;

            await context.SaveChangesAsync();
        }

        private static async Task InsertDataRecord(FootballLeageDbContext context)
        {
            var newCoach = new Coach
            {
                Name = "Jose Mourinho",
                CreatedDate = DateTime.UtcNow
            };

            //await context.AddAsync(newCoach);
            //await context.SaveChangesAsync();

            var newCoach1 = new Coach
            {
                Name = "Theodore Whitmore",
                CreatedDate = DateTime.UtcNow
            };

            List<Coach> coaches = new List<Coach>() { newCoach1, newCoach };

            await context.AddRangeAsync(coaches);

            System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);

            await context.SaveChangesAsync();

            System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);

            foreach (var coach in coaches)
            {
                System.Console.WriteLine($"{coach.Id} - {coach.Name}");
            }
        }

        private static async Task ListVsQueryable(FootballLeageDbContext context)
        {
            System.Console.WriteLine("Enter '1' for Team with Id 1 or '2' for teams that contain 'F.C.'");

            var option = Convert.ToInt32(System.Console.ReadLine());
            List<Team> teamsAsList = new List<Team>();

            teamsAsList = await context.Teams.ToListAsync();

            if (option == 1)
            {
                teamsAsList = teamsAsList.Where(team => team.Id == 1).ToList();
            }
            else if (option == 2)
            {
                teamsAsList = teamsAsList.Where(team => team.Name.Contains("F.C.")).ToList();
            }

            foreach (Team team in teamsAsList)
            {
                System.Console.WriteLine(team.Name);
            }

            var teamsAsQueryable = context.Teams.AsQueryable();

            if (option == 1)
            {
                teamsAsQueryable = teamsAsQueryable.Where(team => team.Id == 1);
            }
            else if (option == 2)
            {
                teamsAsQueryable = teamsAsQueryable.Where(team => team.Name.Contains("F.C."));
            }

            teamsAsList = await teamsAsQueryable.ToListAsync();

            foreach (Team team in teamsAsList)
            {
                System.Console.WriteLine(team.Name);
            }
        }

        private static async Task NoTracking(FootballLeageDbContext context)
        {
            var teams = await context.Teams
                                     .AsNoTracking()
                                     .ToListAsync();

            foreach (Team team in teams)
            {
                System.Console.WriteLine(team.Name);
            }
        }

        private static async Task ProjectionAndSelect(FootballLeageDbContext context)
        {
            var teamsNames = await context.Teams
                                     .Select(team => new { team.Name, team.CreatedDate })
                                     .ToListAsync();

            foreach (var team in teamsNames)
            {
                System.Console.WriteLine($"{team.Name} - {team.CreatedDate}");
            }
        }

        private static async Task SkipAndTake(FootballLeageDbContext context)
        {
            var recordCount = 3;
            var page = 0;
            var next = true;

            while (next)
            {
                var teams = await context.Teams
                                         .Skip(page * recordCount)
                                         .Take(recordCount)
                                         .ToListAsync();

                foreach (var team in teams)
                {
                    System.Console.WriteLine(team.Name);
                }

                System.Console.Write("NextPage?  ");
                next = Convert.ToBoolean(System.Console.ReadLine());

                if (!next)
                {
                    break;
                }

                ++page;
            }
        }

        private static void OrderByMethod(FootballLeageDbContext context)
        {
            var orderedTeams = context.Teams
                                      .OrderBy(team => team.Name);

            foreach (Team team in orderedTeams)
            {
                System.Console.WriteLine(team.Name);
            }

            var descOrderedTeams = context.Teams
                                          .OrderByDescending(team => team.Name);

            foreach (Team team in descOrderedTeams)
            {
                System.Console.WriteLine(team.Name);
            }
        }

        private static void GroupByMethod(FootballLeageDbContext context)
        {
            var groupedTeams = context.Teams
                                      .GroupBy(team => team.CreatedDate.Date);

            foreach (var group in groupedTeams)
            {
                System.Console.WriteLine(group.Key);
                System.Console.WriteLine(group.Sum(team => team.Id));

                foreach (var team in group)
                {
                    System.Console.WriteLine(team.Name);
                }
            }
        }

        private static async Task AggarateMethods(FootballLeageDbContext context)
        {
            var numberOfTeams = await context.Teams.CountAsync();
            var numberOfTeamsWithCondition = await context.Teams.CountAsync(team => team.Id == 1);

            System.Console.WriteLine($"numberOfTeams = {numberOfTeams}; numberOfTeamsWithCondition = {numberOfTeamsWithCondition}");

            var maxTeams = await context.Teams.MaxAsync(team => team.Id);
            var minTeams = await context.Teams.MinAsync(team => team.Id);
            var avgTeams = await context.Teams.AverageAsync(team => team.Id);
            var sumTeams = await context.Teams.SumAsync(team => team.Id);

            System.Console.WriteLine($"maxTeams = {maxTeams}; minTeams = {minTeams}; avgTeams = {avgTeams}; sumTeams = {sumTeams}");
        }

        private static void GetAllTeamsQuerySyntax(FootballLeageDbContext context)
        {
            System.Console.Write("Enter Desired Team:  ");

            var desiredTeam = System.Console.ReadLine();
            var teams = from team in context.Teams
                        where EF.Functions.Like(team.Name, $"%{desiredTeam}%")
                        select team;

            foreach (Team team in teams)
            {
                System.Console.WriteLine(team.Name);
            }
        }

        private static void GetFilteredTeams(FootballLeageDbContext context)
        {
            System.Console.Write("Enter Desired Team:  ");

            var desiredTeam = System.Console.ReadLine();
            var teamsFiltered = context.Teams.Where(team => team.Name == desiredTeam);

            foreach (var team in teamsFiltered)
            {
                System.Console.WriteLine(team.Name);
            }

            //var partialMatches = context.Teams.Where(team => team.Name.Contains(desiredTeam));
            var partialMatches = context.Teams.Where(team => EF.Functions.Like(team.Name, $"%{desiredTeam}%"));

            foreach (var team in partialMatches)
            {
                System.Console.WriteLine(team.Name);
            }
        }

        private static async Task GetAllTeams(FootballLeageDbContext context)
        {
            var teams = await context.Teams.ToListAsync();

            foreach (Team team in teams)
            {
                System.Console.WriteLine(team.Name);
            }
        }

        private static async Task GetOneTeam(FootballLeageDbContext context)
        {
            var teamOne = await context.Teams.FirstAsync();

            var teamTwo = await context.Teams.FirstAsync(team => team.Id == 1);

            var teamThree = await context.Teams.SingleAsync(team => team.Id == 2);

            var teamBaseOnId = await context.Teams.FindAsync(3);
        }
    }
}
