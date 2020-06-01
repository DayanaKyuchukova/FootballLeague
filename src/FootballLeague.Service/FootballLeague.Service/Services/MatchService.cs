using FootballLeague.DAL.Interfaces;
using FootballLeague.Domain.Entities;
using FootballLeague.Service.Interfaces;
using FootballLeague.Service.Models;
using FootballLeague.Service.Nomenclatures;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Service.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchResponseModel>> GetAllAsync()
        {
            var matches = await matchRepository.QueryAsync(m => m.IsDeleted == false && m.Status == (int)StatusType.Played);

            return matches.Select(resp => new MatchResponseModel
            {
                Id = resp.Id,
                Name = resp.Name,
                IsDeleted = resp.IsDeleted,
                TeamMatches = resp.TeamMatches
            });
        }

        public Task CreateAsync(MatchRequestModel model)
        {
            var match = new Match { Name = model.Name, Status = model.Status, TeamMatches = model.TeamMatches.ToList() };

            return matchRepository.CreateAsync(match);
        }

        public async Task UpdateAsync(int id, string name, int[] scores)
        {
            var match = await matchRepository.GetByIdAsync(id);

            match.Name = name;
            match.Status = (int)StatusType.Played;

            for (int i = 0; i < 2; i++)
            {
                match.TeamMatches.ToArray()[i].Score = scores[i];
            }

            await matchRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var match = await matchRepository.GetByIdAsync(id);

            await matchRepository.SoftDeleteAsync(match);
        }
    }
}
