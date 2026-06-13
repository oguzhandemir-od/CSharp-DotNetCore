using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Features.Dashboard
{
    [Authorize(Roles = "Admin,Author")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            var isAdmin = User.IsInRole("Admin");

            var model = await _dashboardService.GetDashboardStatsAsync(userId, isAdmin);
            model.UserFullName = User.Identity?.Name ?? "Kullanıcı";

            return View(model);
        }
    }
}
