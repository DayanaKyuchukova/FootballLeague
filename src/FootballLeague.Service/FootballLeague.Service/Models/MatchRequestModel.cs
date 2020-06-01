using FootballLeague.Domain.Entities;
using FootballLeague.Service.Nomenclatures;
using System.Collections.Generic;

namespace FootballLeague.Service.Models
{
    public class MatchRequestModel
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public IEnumerable<TeamMatch> TeamMatches { get; set; }
    }
}
