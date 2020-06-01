using FootballLeague.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FootballLeague.DAL.Configurations
{
    public class TeamMatchEntityConfiguration : EntityTypeConfiguration<TeamMatch>
    {
        public TeamMatchEntityConfiguration()
        {
            ToTable(nameof(TeamMatch));
            HasKey(t => t.Id);

            HasRequired(tm => tm.Team)
                .WithMany(t => t.TeamMatches);
            HasRequired(tm => tm.Match)
                .WithMany(m => m.TeamMatches);
        }
    }
}
