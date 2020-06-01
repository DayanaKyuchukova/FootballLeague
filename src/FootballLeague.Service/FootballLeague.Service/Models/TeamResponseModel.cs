using FootballLeague.Domain.Entities;
using System.Collections.Generic;

namespace FootballLeague.Service.Models
{
    public class TeamResponseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<TeamMatch> TeamMatches { get; set; }
    }
}
