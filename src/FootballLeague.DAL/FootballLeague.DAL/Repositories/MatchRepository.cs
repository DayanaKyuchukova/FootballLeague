using FootballLeague.DAL.Interfaces;
using FootballLeague.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.DAL.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        private readonly ApplicationDbContext context;

        public MatchRepository(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<Match> GetByIdAsync(long id)
        {

            var result = await DbSet.FindAsync(id);
            return result;
        }

        public Task CreateAsync(Match match, TeamMatch firstTeam, TeamMatch secondTeam)
        {
            DbSet.Add(match);

            context.TeamMatches.Add(firstTeam);
            context.TeamMatches.Add(secondTeam);

            return SaveChangesAsync();
        }

        public Task SoftDeleteAsync(Match match)
        {
            match.IsDeleted = true;

            var teamMatches = context.TeamMatches.Where(tm => tm.MatchId == match.Id).ToList();

            context.TeamMatches.RemoveRange(teamMatches);

            return SaveChangesAsync();
        }
    }
}
