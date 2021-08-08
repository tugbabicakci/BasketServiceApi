using BasketService.Api.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BasketService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly Service.BasketService basketService;
        private readonly ProductService productService;

        public BasketController(Service.BasketService basketService, ProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }

        [HttpGet("Get")]

        public async Task<IActionResult> Get([Required] int id)
        {
            var result = await basketService.Get(id);

            if (result == null)
                return NotFound("Basket bulunamadı!");

            return Ok(result);
        }


        [HttpPost("AddBasket")]
        public async Task<IActionResult> AddBasket([Required] int productId, [Required] int total, int basketId)
        {
            var product = await productService.Get(productId);

            if (product == null)
                return NotFound("Ürün bulunamadı!");

            var addBasket = await basketService.AddBasket(productId, total, basketId);

            if (addBasket == null)
                return NotFound("Ürün sepete eklenemedi!");

            return Ok(addBasket);
        }

    }
}
