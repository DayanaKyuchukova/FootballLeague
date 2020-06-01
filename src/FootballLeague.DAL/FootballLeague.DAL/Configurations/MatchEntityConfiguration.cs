using FootballLeague.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FootballLeague.DAL.Configurations
{
    public class MatchEntityConfiguration : EntityTypeConfiguration<Match>
    {
        public MatchEntityConfiguration()
        {
            ToTable(nameof(Match));
            HasKey(m => m.Id);
        }
    }
}
