using FootballLeague.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FootballLeague.DAL.Configurations
{
    public class ScoreResultTypeEntityConfiguration : EntityTypeConfiguration<ScoreResultType>
    {
        public ScoreResultTypeEntityConfiguration()
        {
            ToTable(nameof(ScoreResultType));
            HasKey(m => m.Id);
        }
    }
}
