using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            var teamMembers = new List<TeamListModel>
            {
                new TeamListModel { Id = 1, Name = "John Doe", Designation = "Developer" },
                new TeamListModel { Id = 2, Name = "Jane Smith", Designation = "Designer" },
                new TeamListModel { Id = 3, Name = "Bob Johnson", Designation = "Project Manager" }
            };
            return View(teamMembers);
        }
    }
}
