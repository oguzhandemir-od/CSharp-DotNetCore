using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Features.Error
{
    public class ErrorController: Controller
    {
        [Route("/Error/500")]
        public IActionResult Error500()
        {
            return View("~/Views/Error/500.cshtml");

        }
    }
}
