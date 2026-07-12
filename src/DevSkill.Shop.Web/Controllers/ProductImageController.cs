using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevSkill.Shop.Web.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(
            IApplicationUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int? productId)
        {
            try
            {
                var products = _unitOfWork.Products
                    .GetAll()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = $"{x.Name} (ID: {x.Id})",
                        Selected = productId == x.Id
                    })
                    .ToList();


                var images = new List<ProductImage>();

                if (productId.HasValue)
                {
                    images = _unitOfWork.ProductImages
                        .Find(x => x.ProductId == productId.Value)
                        .ToList();
                }


                var model = new ProductImageIndexModel
                {
                    SelectedProductId = productId ?? 0,
                    Products = products,
                    Images = images
                };


                return View(model);

            }
            catch
            {
                TempData["Error"] = "Unable to load product images.";

                return RedirectToAction("Index", "Products");
            }
        }

        public IActionResult Create(int productId)
        {
            try
            {
                var model = new ProductImageModel
                {
                    ProductId = productId
                };

                return View(model);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to open image upload page.";
                return RedirectToAction(nameof(Index), new { productId });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductImageModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                string fileName = Guid.NewGuid().ToString() +
                                  Path.GetExtension(model.ImageFile.FileName);

                string folder = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "products");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                ProductImage image = new ProductImage
                {
                    ProductId = model.ProductId,
                    Serial = model.Serial,
                    ImageName = fileName
                };

                _unitOfWork.ProductImages.Add(image);
                _unitOfWork.Save();

                TempData["Success"] = "Product image added successfully.";

                return RedirectToAction(nameof(Index),
                    new { productId = model.ProductId });
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to add product image.";
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var image = _unitOfWork.ProductImages.GetById(id);

                if (image == null)
                    return NotFound();

                return View(image);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to load product image.";
                return RedirectToAction("Index", "Products");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var image = _unitOfWork.ProductImages.GetById(id);

                if (image == null)
                    return NotFound();

                string filePath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "products",
                    image.ImageName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                int productId = image.ProductId;

                _unitOfWork.ProductImages.Remove(image);
                _unitOfWork.Save();

                TempData["Success"] = "Product image deleted successfully.";

                return RedirectToAction(nameof(Index), new { productId });
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to delete product image.";
                return RedirectToAction("Index", "Products");
            }
        }
    }
}