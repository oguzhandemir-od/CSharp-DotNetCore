using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageError()
        {
            var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();
            if (statusCodePagesFeature != null)
            {
                statusCodePagesFeature.Enabled = false;
            }

            Response.StatusCode = 404;
            return View();
        }

        public IActionResult Page400()
        {
            var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();
            if (statusCodePagesFeature != null)
            {
                statusCodePagesFeature.Enabled = false;
            }

            Response.StatusCode = 400;
            return View();
        }

        public IActionResult Page403()
        {
            var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();
            if (statusCodePagesFeature != null)
            {
                statusCodePagesFeature.Enabled = false;
            }

            Response.StatusCode = 403;
            return View();
        }

        public IActionResult Page404()
        {
            var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();
            if (statusCodePagesFeature != null)
            {
                statusCodePagesFeature.Enabled = false;
            }

            Response.StatusCode = 404;
            return View();
        }
    }
}
