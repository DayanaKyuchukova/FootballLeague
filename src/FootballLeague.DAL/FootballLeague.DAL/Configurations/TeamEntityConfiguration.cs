using FootballLeague.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FootballLeague.DAL.Configurations
{
    public class TeamEntityConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamEntityConfiguration()
        {
            ToTable(nameof(Team));
            HasKey(t => t.Id);
        }
    }
}
