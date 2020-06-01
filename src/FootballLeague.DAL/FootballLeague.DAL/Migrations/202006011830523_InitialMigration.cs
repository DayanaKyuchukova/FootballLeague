namespace FootballLeague.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamMatch",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        TeamId = c.Long(nullable: false),
                        MatchId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Match", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScoreResultType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMatch", "TeamId", "dbo.Team");
            DropForeignKey("dbo.TeamMatch", "MatchId", "dbo.Match");
            DropIndex("dbo.TeamMatch", new[] { "MatchId" });
            DropIndex("dbo.TeamMatch", new[] { "TeamId" });
            DropTable("dbo.ScoreResultType");
            DropTable("dbo.Team");
            DropTable("dbo.TeamMatch");
            DropTable("dbo.Match");
        }
    }
}
