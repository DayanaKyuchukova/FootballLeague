using FootballLeague.Service.Interfaces;
using FootballLeague.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FootballLeague.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet()]
        public async Task<ActionResult> TeamRanking()
        {
            var result = (await teamService.GetTeamsRanking()).ToList();

            var teamsRanking = result.Select(tr => new TeamRanking { TeamName = tr.TeamName, Points = tr.Points }).ToList();

            return View(teamsRanking);
        }
    }
}
