using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Features.Users
{
    [Authorize(Roles = "Admin")] 
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: /User/Index
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAdminUsersAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string fullName, string role)
        {
            var result = await _userService.UpdateUserAsync(id, fullName, role);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return Json(result);
        }
    }
}
