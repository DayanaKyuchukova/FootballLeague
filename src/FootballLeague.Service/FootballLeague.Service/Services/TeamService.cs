using FootballLeague.DAL.Interfaces;
using FootballLeague.Domain.Entities;
using FootballLeague.Service.Interfaces;
using FootballLeague.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamRankingModel>> GetTeamsRanking()
        {
            var teams = teamRepository.GetTeamsRanking();

            return teams.Select(t => new TeamRankingModel { TeamName = t.TeamName, Points = t.Points });
        }

        public async Task<IEnumerable<TeamResponseModel>> GetAllAsync()
        {
            var teams = await teamRepository.QueryAsync(t => t.IsDeleted == false);

            return teams.Select(resp => new TeamResponseModel
            {
                Id = resp.Id,
                Name = resp.Name,
                IsDeleted = resp.IsDeleted,
                TeamMatches = resp.TeamMatches
            });
        }

        public async Task<TeamResponseModel> GetAsync(long id)
        {
            var team = await teamRepository.GetByIdAsync(id);

            return new TeamResponseModel { Id = team.Id, Name = team.Name };
        }

        public Task CreateAsync(string name)
        {
            var team = new Team { Name = name };

            return teamRepository.CreateAsync(team);
        }

        public async Task UpdateAsync(int id, string name)
        {
            var team = await teamRepository.GetByIdAsync(id);

            team.Name = name;

            await teamRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var team = await teamRepository.GetByIdAsync(id);

            await teamRepository.SoftDeleteAsync(team);
        }
    }
}
