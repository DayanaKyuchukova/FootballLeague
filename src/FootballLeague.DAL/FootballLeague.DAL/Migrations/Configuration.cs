using FootballLeague.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace FootballLeague.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            IList<ScoreResultType> scoreResultTypes = new List<ScoreResultType>()
            {
                new ScoreResultType() { Id = 1, Name = "Draw", Points = 1 },
                new ScoreResultType() { Id = 2, Name = "Win", Points = 3 },
                new ScoreResultType() { Id = 3, Name = "Loss", Points = 0 }
            };

            context.ScoreResultTypes.AddRange(scoreResultTypes);

            base.Seed(context);
        }
    }
}
