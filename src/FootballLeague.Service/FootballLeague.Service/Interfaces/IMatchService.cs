using FootballLeague.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Service.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchResponseModel>> GetAllAsync();

        Task CreateAsync(MatchRequestModel model);

        Task UpdateAsync(int id, string name, int[] scores);

        Task DeleteAsync(int id);
    }
}
