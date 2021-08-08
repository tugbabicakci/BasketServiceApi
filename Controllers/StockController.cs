using BasketService.Api.Model;
using BasketService.Api.Service;
using MicroserviceTemplate.Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BasketService.Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService stockService;
        public StockController(StockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await stockService.GetAll();
            return Ok(result);
        }

        [HttpPut("ChangeAmount")]
        public async Task<IActionResult> ChangeAmount([Required] int productId, [Required] int productTotal)
        {
            var changeAmountResponse = await stockService.ChangeAmount(productId, productTotal);
            if (changeAmountResponse != null)
                return Ok(new ApiResult<Stock>(changeAmountResponse, true, "Stok azaltıldı."));

            return NotFound(new ApiResult<Stock>(null, false, "Stokta ürün bulunamadı!"));
        }
    }
}
