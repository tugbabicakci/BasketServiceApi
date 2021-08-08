using BasketService.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketService.Api.Service
{
    public class StockService
    {
        private readonly BasketContext _basketContext;

        public StockService(BasketContext basketContext)
        {
            _basketContext = basketContext;

            if (basketContext.Stocks.Count() == 0)
            {
                basketContext.Stocks.Add(new Stock { ProductId = 1, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 2, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 3, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 4, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 5, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 6, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 7, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 8, Amount = 3 });
                basketContext.Stocks.Add(new Stock { ProductId = 9, Amount = 3 });

                _basketContext.SaveChanges();
            }
        }


        public async Task<List<Stock>> GetAll()
        {
            return _basketContext.Stocks.ToList();
        }

        public async Task<Stock> ChangeAmount(int productId, int totalProduct)
        {
            var stock = await _basketContext.Stocks.FindAsync(productId);
            if (stock != null)
            {
                if (stock.Amount > 0)
                {
                    stock.Amount -= totalProduct;
                    _basketContext.Update(stock);

                    _basketContext.SaveChanges();

                    return stock;
                }
            }
            return null;
        }
    }
}
