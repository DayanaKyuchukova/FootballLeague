using FootballLeague.Domain.Entities;
using System.Threading.Tasks;

namespace FootballLeague.DAL.Interfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        Task<Match> GetByIdAsync(long id);

        Task CreateAsync(Match match, TeamMatch firstTeam, TeamMatch secondTeam);

        Task SoftDeleteAsync(Match match);
    }
}
