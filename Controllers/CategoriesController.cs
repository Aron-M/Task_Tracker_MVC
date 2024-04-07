using Microsoft.AspNetCore.Mvc;
using TaskTrackerMVC.Models;
using TaskTrackerMVC.Services;
using System.Threading.Tasks;

namespace TaskTrackerMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryAPIService _categoryAPIService;

        public CategoriesController(CategoryAPIService categoryAPIService)
        {
            _categoryAPIService = categoryAPIService;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryAPIService.GetAllCategoriesAsync();
            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryAPIService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name,Description")] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryAPIService.CreateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryAPIService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name,Description")] CategoryModel category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoryAPIService.UpdateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryAPIService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryAPIService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}