using BlogProject.Domain.Entities;
using BlogProject.Features.Categories;
using BlogProject.Features.Categories.DTOs;
using BlogProject.Features.Comments.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Features.Comments
{
    public class CommentController : Controller
    {
        private readonly CommentService _commentService;
        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize(Roles = "Admin,Author")]

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return View(comments);
        }

        [Authorize(Roles = "Admin,Author")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var result = await _commentService.UpdateStatusAsync(id, status);
            return Json(new { success = result.IsSuccess, message = result.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Lütfen geçerli bir yorum yazın." });
            }

            try
            {
                await _commentService.AddCommentAsync(dto);

                return Json(new { success = true, message = "Yorumunuz alındı, onaylandıktan sonra listelenecektir." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Sistemsel bir hata oluştu: " + ex.Message });
            }
        }

    }
}
