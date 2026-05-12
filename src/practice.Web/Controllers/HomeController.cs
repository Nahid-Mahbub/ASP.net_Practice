using Microsoft.AspNetCore.Mvc;
using practice.Web.Models;
using System.Diagnostics;
using Serilog;
using Practice.Web.Codes;


namespace practice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembership _membership;
        private readonly ILogger<HomeController> _logger;
        public HomeController([FromKeyedServices("Setup 1")] IMembership membership, ILogger<HomeController> logger) // Dependency Injection of the Membership service, Logger service
        {
            _membership = membership;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 100 },
                new Product { Id = 2, Name = "Product 2", Price = 200 },
                new Product { Id = 3, Name = "Product 3", Price = 300 }
            };
            Log.Debug("Index action of HomeController is called.");
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
