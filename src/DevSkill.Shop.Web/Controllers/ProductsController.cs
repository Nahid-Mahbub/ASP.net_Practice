using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevSkill.Shop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductsController(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = _unitOfWork.Products.GetAll();
            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _unitOfWork.Categories.GetAll(),
                "Id",
                "Name");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Categories = new SelectList(
                        _unitOfWork.Categories.GetAll(),
                        "Id",
                        "Name");

                    return View(product);
                }

                _unitOfWork.Products.Add(product);
                _unitOfWork.Save();

                TempData["Success"] = "Product created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Something went wrong while creating the product.";

                ViewBag.Categories = new SelectList(
                    _unitOfWork.Categories.GetAll(),
                    "Id",
                    "Name");

                return View(product);
            }
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Products.GetById(id);

            if (product == null)
                return NotFound();

            ViewBag.Categories = new SelectList(
                _unitOfWork.Categories.GetAll(),
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Categories = new SelectList(
                        _unitOfWork.Categories.GetAll(),
                        "Id",
                        "Name",
                        product.CategoryId);

                    return View(product);
                }

                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();

                TempData["Success"] = "Product updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Something went wrong while updating the product.";

                ViewBag.Categories = new SelectList(
                    _unitOfWork.Categories.GetAll(),
                    "Id",
                    "Name",
                    product.CategoryId);

                return View(product);
            }
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = _unitOfWork.Products.GetById(id);

                if (product == null)
                    return NotFound();

                _unitOfWork.Products.Remove(product);
                _unitOfWork.Save();

                TempData["Success"] = "Product deleted successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Something went wrong while deleting the product.";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}