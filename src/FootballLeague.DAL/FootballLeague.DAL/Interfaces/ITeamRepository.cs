using FootballLeague.DAL.Models;
using FootballLeague.Domain.Entities;
using System.Collections.Generic;

namespace FootballLeague.DAL.Interfaces
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        IEnumerable<TeamRanking> GetTeamsRanking();
    }
}
