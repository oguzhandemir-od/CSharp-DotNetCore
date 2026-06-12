using BlogProject.Domain.Entities;
using BlogProject.Features.Categories.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Features.Categories
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var dto = await _categoryService.GetByIdAsync(id);

        //    if (dto == null)
        //        return NotFound("Kategori bulunamadı.");

        //    return View(dto);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CategoryDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return View(dto);

        //    await _categoryService.AddCategoryAsync(dto);

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var dto = await _categoryService.GetByIdAsync(id);
        //    if (dto == null) return NotFound();

        //    return View(dto);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(CategoryDto dto)
        //{           

        //    await _categoryService.EditCategoryAsync(dto.Id,dto);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Lütfen geçerli bir kategori adı girin." });

            var result = await _categoryService.SaveOrUpdateCategoryAsync(categoryDto);
            return Json(new { success = result.IsSuccess, message = result.Message });
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var dto = await _categoryService.GetByIdAsync(id);

        //    if (dto == null)
        //        return NotFound();

        //    return View(dto);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //    await _categoryService.DeleteCategoryAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return Json(new { success = result.IsSuccess, message = result.Message });
        }

    }
}
