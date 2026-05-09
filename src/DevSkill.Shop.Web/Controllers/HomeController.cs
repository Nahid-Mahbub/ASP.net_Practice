using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Serilog;

namespace DevSkill.Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestError()
        {
            Log.Information("TestError method hit");

            try
            {
                int x = 10;
                int y = 0;

                int result = x / y;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Test division error");
            }

            return Content("Check logs in database");
        }
    }
}
