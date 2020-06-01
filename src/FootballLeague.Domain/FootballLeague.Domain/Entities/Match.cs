using System.Collections.Generic;

namespace FootballLeague.Domain.Entities
{
    public class Match : BaseEntity<long>, IDeletable
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
