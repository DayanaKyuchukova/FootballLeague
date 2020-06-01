namespace FootballLeague.Domain.Entities
{
    public class TeamMatch : BaseEntity<long>
    {
        public int Score { get; set; }

        public long TeamId { get; set; }

        public long MatchId { get; set; }

        public virtual Team Team { get; set; }

        public virtual Match Match { get; set; }
    }
}
