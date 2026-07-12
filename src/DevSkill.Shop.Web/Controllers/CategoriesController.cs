using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CategoriesController(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Categories
        public IActionResult Index()
        {
            try
            {
                var categories = _unitOfWork.Categories.GetAll();

                return View(categories);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to load categories.";

                return RedirectToAction("Index", "Home");
            }
        }



        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }


                _unitOfWork.Categories.Add(category);

                _unitOfWork.Save();


                TempData["Success"] =
                    "Category created successfully.";


                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "Something went wrong while creating category.";


                return View(category);
            }
        }





        // GET: Categories/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var category =
                    _unitOfWork.Categories.GetById(id);


                if (category == null)
                {
                    TempData["Error"] =
                        "Category not found.";

                    return RedirectToAction(nameof(Index));
                }


                return View(category);
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "Unable to load category information.";


                return RedirectToAction(nameof(Index));
            }
        }





        // POST: Categories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }


                var existingCategory =
                    _unitOfWork.Categories.GetById(category.Id);


                if (existingCategory == null)
                {
                    TempData["Error"] =
                        "Category not found.";

                    return RedirectToAction(nameof(Index));
                }



                existingCategory.Name = category.Name;

                existingCategory.IsActive = category.IsActive;

                existingCategory.ImageName = category.ImageName;



                _unitOfWork.Categories.Update(existingCategory);

                _unitOfWork.Save();



                TempData["Success"] =
                    "Category updated successfully.";


                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "Something went wrong while updating category.";


                return View(category);
            }
        }





        // GET: Categories/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var category =
                    _unitOfWork.Categories.GetById(id);


                if (category == null)
                {
                    TempData["Error"] =
                        "Category not found.";

                    return RedirectToAction(nameof(Index));
                }


                return View(category);
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "Unable to load delete page.";


                return RedirectToAction(nameof(Index));
            }
        }





        // POST: Categories/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category =
                    _unitOfWork.Categories.GetById(id);



                if (category == null)
                {
                    TempData["Error"] =
                        "Category not found.";

                    return RedirectToAction(nameof(Index));
                }



                _unitOfWork.Categories.Remove(category);

                _unitOfWork.Save();



                TempData["Success"] =
                    "Category deleted successfully.";


                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "Unable to delete category.";


                return RedirectToAction(nameof(Index));
            }
        }

    }
}