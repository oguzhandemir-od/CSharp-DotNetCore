using BlogProject.Features.Categories;
using BlogProject.Features.Posts.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Features.Posts
{
    [Authorize(Roles = "Admin,Author")]
    public class PostController : Controller
    {
        private readonly PostService _postService;
        private readonly CategoryService _categoryService;
        public PostController(PostService postService,CategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dashboardPosts = await _postService.GetDashboardPostsAsync();
            return View(dashboardPosts); 
        }

        [HttpGet]
        public async Task<IActionResult> DashboardDetails(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();

            if (User.IsInRole("Admin") == false && post.AuthorName != User.Identity.Name)
                return Forbid();

            return View(post); 
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var emptyDto = new PostDto();
            return View(emptyDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Author")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _postService.GetPostForEditAsync(id);

            if (dto == null) return Forbid();

            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", dto.CategoryId);

            return View("Create", dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Author")]
        public async Task<IActionResult> Save(PostDto dto)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", dto.CategoryId);

            if (!ModelState.IsValid)
            {
                return View("Create", dto);
            }

            var result = await _postService.SaveOrUpdatePostAsync(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View("Create", dto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Author")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePostAsync(id);

            if (!result.IsSuccess)
            {
                return Json(new { success = false, message = result.Message });
            }

            return Json(new { success = true, message = "Makale başarıyla silindi." });
        }
    }
}
