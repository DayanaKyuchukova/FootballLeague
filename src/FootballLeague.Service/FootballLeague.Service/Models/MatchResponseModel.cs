using FootballLeague.Domain.Entities;
using System.Collections.Generic;

namespace FootballLeague.Service.Models
{
    public class MatchResponseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }

        public virtual IEnumerable<TeamMatch> TeamMatches { get; set; }
    }
}
