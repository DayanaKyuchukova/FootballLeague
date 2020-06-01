using FootballLeague.DAL.Configurations;
using FootballLeague.Domain.Entities;
using System.Data.Entity;

namespace FootballLeague.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base()
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<TeamMatch> TeamMatches { get; set; }

        public DbSet<ScoreResultType> ScoreResultTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeamEntityConfiguration());
            modelBuilder.Configurations.Add(new MatchEntityConfiguration());
            modelBuilder.Configurations.Add(new TeamMatchEntityConfiguration());
            modelBuilder.Configurations.Add(new ScoreResultTypeEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}