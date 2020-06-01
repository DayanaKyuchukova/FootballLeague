using System.Collections.Generic;

namespace FootballLeague.Domain.Entities
{
    public class Team : BaseEntity<long>, IDeletable
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
