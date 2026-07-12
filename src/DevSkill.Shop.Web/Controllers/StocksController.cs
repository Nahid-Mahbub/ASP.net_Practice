using DevSkill.Shop.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Web.Controllers
{
    public class StocksController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public StocksController(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                var stocks = _unitOfWork.Stocks.GetAll();

                return View(stocks);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to load stock list.";
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            try
            {
                ViewBag.Products = new SelectList(
                    _unitOfWork.Products.GetAll(),
                    "Id",
                    "Name");

                return View();
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to open create stock page.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Stocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stock stock)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Products = new SelectList(
                        _unitOfWork.Products.GetAll(),
                        "Id",
                        "Name",
                        stock.ProductId);

                    return View(stock);
                }

                _unitOfWork.Stocks.Add(stock);
                _unitOfWork.Save();

                TempData["Success"] = "Stock created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Products = new SelectList(
                    _unitOfWork.Products.GetAll(),
                    "Id",
                    "Name",
                    stock.ProductId);

                TempData["Error"] = "Unable to create stock.";
                return View(stock);
            }
        }

        // GET: Stocks/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var stock = _unitOfWork.Stocks.GetById(id);

                if (stock == null)
                    return NotFound();

                ViewBag.Products = new SelectList(
                    _unitOfWork.Products.GetAll(),
                    "Id",
                    "Name",
                    stock.ProductId);

                return View(stock);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to load stock information.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Stocks/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stock stock)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Products = new SelectList(
                        _unitOfWork.Products.GetAll(),
                        "Id",
                        "Name",
                        stock.ProductId);

                    return View(stock);
                }

                _unitOfWork.Stocks.Update(stock);
                _unitOfWork.Save();

                TempData["Success"] = "Stock updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Products = new SelectList(
                    _unitOfWork.Products.GetAll(),
                    "Id",
                    "Name",
                    stock.ProductId);

                TempData["Error"] = "Unable to update stock.";
                return View(stock);
            }
        }

        // GET: Stocks/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var stock = _unitOfWork.Stocks.GetById(id);

                if (stock == null)
                    return NotFound();

                return View(stock);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to load stock information.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Stocks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var stock = _unitOfWork.Stocks.GetById(id);

                if (stock == null)
                    return NotFound();

                _unitOfWork.Stocks.Remove(stock);
                _unitOfWork.Save();

                TempData["Success"] = "Stock deleted successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to delete stock.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}