namespace FootballLeague.Domain.Entities
{
    public class ScoreResultType : BaseEntity<byte>
    {
        public string Name { get; set; }

        public int Points { get; set; }
    }
}
