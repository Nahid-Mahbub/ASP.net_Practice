using Microsoft.AspNetCore.Mvc;
using practice.Web.Models;
using System.Security.Cryptography.Pkcs;

namespace practice.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var model = new TestModel { Name = "Nahid Mahbub", Email = "Example@gamil.com", Partial = new PartialModel { Address = "Daffodil Smart City" } };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken] //vailete anti forgery token
        public IActionResult Index(TestModel model)
        {
            var Name = model.Name;
            var Email = model.Email;
            var Address = model.Partial?.Address;
            return View(model);
        }
    }
}
