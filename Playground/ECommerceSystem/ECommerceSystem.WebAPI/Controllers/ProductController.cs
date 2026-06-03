using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetProducts()
        {
            return Ok(new List<string> { "Laptop", "Telefon", "Kulaklık" });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct()
        {
            return Ok("Ürün başarıyla eklendi (Sadece Adminler görebilir).");
        }
    }
}
