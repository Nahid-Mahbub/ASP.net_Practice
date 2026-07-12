using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace DevSkill.Shop.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public TeamController(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Create()
        {
            var team = new Team
            {
                
                Name = "Nahid Mahbub",
                Designation = "Software Development",
                ImageUrl = "Image.jpg"
            };

            _unitOfWork.Teams.Add(team);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {

            var teamMembers = new List<TeamListModel>
            {
                new TeamListModel
                {
                    Id = 1,
                    Name = "John Doe",
                    Designation = "Software Engineer",
                    ImageUrl = "https://randomuser.me/api/portraits/men/32.jpg"
                },

                new TeamListModel
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Designation = "UI/UX Designer",
                    ImageUrl = "https://randomuser.me/api/portraits/men/44.jpg"
                },

                new TeamListModel
                {
                    Id = 3,
                    Name = "Bob Johnson",
                    Designation = "Project Manager",
                    ImageUrl = "https://randomuser.me/api/portraits/men/75.jpg"
                },

                new TeamListModel
                {
                    Id = 4,
                    Name = "Roy Brown",
                    Designation = "Backend Developer",
                    ImageUrl = "https://randomuser.me/api/portraits/men/65.jpg"
                }
            };

            return View(teamMembers);
        }
    }
}