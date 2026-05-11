using Microsoft.AspNetCore.Mvc;
using practice.Web.Models;
using System.Diagnostics;
using practice.Web.Codes;

namespace practice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembership _membership;
        public HomeController(IMembership membership) // Dependency Injection of the Membership service 
        {
            _membership = membership;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel model)
        {
            _membership.CreateUserAccount(model.UserName, model.Password);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
