using BlogProject.Features.Posts;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.Features
{
    public class HomeController : Controller
    {
        private readonly PostService _postService;

        public HomeController(PostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPublicPostsAsync();
            return View(posts); 
        }

        public async Task<IActionResult> PostDetails(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();
            return View(post); 
        }
    }
}
