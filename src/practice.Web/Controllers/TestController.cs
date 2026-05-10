using Microsoft.AspNetCore.Mvc;
using practice.Web.Models;
using System.Security.Cryptography.Pkcs;

namespace practice.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var model = new TestModel { Name = "Nahid Mahbub", Email = "Example@gamil.com" };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(TestModel model)
        {
            var Name = model.Name;
            var Email = model.Email;
            return View(model);
        }
    }
}
