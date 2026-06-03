using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ECommerceSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public ProductController(IDistributedCache cache) 
        { 
            _cache = cache;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            string cacheKey = "products_list";

            var cacheProducts=await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheProducts))
            {
                var productsFromCache = JsonSerializer.Deserialize<List<string>>(cacheProducts);
                return Ok(new { Source = "Redis Cache (RAM)", Data = productsFromCache });
            }

            var dbProducts = new List<string> { "Laptop", "Telefon", "Kulaklık", "Akıllı Saat" };

            var jsonProducts = JsonSerializer.Serialize(dbProducts);

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            };

            await _cache.SetStringAsync(cacheKey, jsonProducts,cacheOptions);

            return Ok(new { Source = "Database (SQL Server)", Data = dbProducts });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct()
        {
            string cacheKey = "products_list";
            await _cache.RemoveAsync(cacheKey);

            Console.WriteLine($"Yeni ürün başarıyla eklendi (Sadece Adminler görebilir). {cacheKey} isimli Redis cache'i temizlendi.");

            return Ok("Ürün başaryla oluşturuldu ve eski önbellek temizlendi. İlk istekte güncel liste oluşturulacak.");
        }
    }
}
