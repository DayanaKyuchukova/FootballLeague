using FootballLeague.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Service.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamRankingModel>> GetTeamsRanking();

        Task<IEnumerable<TeamResponseModel>> GetAllAsync();

        Task<TeamResponseModel> GetAsync(long id);

        Task CreateAsync(string name);

        Task UpdateAsync(int id, string name);

        Task DeleteAsync(int id);
    }
}
