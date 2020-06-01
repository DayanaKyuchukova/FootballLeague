using FootballLeague.DAL.Interfaces;
using FootballLeague.DAL.Models;
using FootballLeague.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.DAL.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext context;

        public TeamRepository(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public IEnumerable<TeamRanking> GetTeamsRanking()
            => context.Teams.Where(t => t.IsDeleted == false)
                .Join(context.TeamMatches,
                    team => team.Id,
                    teamMatch => teamMatch.TeamId,
                    (t, tm) => new { t, TeamScore = tm.Score })
                    .GroupBy(res => res.t.Id)
                    .Select(gr => new TeamRanking
                    {
                         Points = gr.Sum(t => t.TeamScore),
                         TeamName = gr.FirstOrDefault().t.Name
                    })
                    .ToList()
                    .OrderByDescending(tr => tr.Points);
    }
}
