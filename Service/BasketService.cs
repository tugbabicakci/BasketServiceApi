using BasketService.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketService.Api.Service
{
    public class BasketService
    {
        private readonly ProductService productService;
        private readonly StockService stockService;
        private readonly BasketContext basketContext;

        public BasketService(
            BasketContext basketContext,
            ProductService productService,
            StockService stockService)
        {
            this.basketContext = basketContext;
            this.productService = productService;
            this.stockService = stockService;
        }

        public async Task<Basket> Create(Basket basket)
        {
            var result = await basketContext.Baskets.AddAsync(basket);
            basketContext.SaveChanges();

            return result.Entity;
        }

        public async Task<List<Basket>> GetAll()
        {
            var result = basketContext.Baskets.ToList();

            return result;
        }

        public async Task<Basket> Get(int id)
        {
            var basket = await basketContext.Baskets
                .Include(x => x.Product)
                .FirstAsync(x => x.Id == id);
            return basket;
        }

        public async Task<Basket> AddBasket(int productId, int total, int basketId)
        {
            var product = await productService.Get(productId);

            if (product != null)
            {
                product.Total = product.Total == 0 ? total : (product.Total + total);

                var basket = basketContext.Baskets.FirstOrDefault(x => x.Id == basketId);
                if (basket != null)
                {
                    basket.Product.Add(product);
                    var changeAmount = await stockService.ChangeAmount(productId, total);

                    if (changeAmount == null)
                        return null;

                    basketContext.SaveChanges();
                    return basket;
                }
                else
                {
                    var changeAmountResponse = await stockService.ChangeAmount(productId, total);

                    if (changeAmountResponse != null)
                    {
                        var newBasket = new Basket
                        {
                            UserId = Guid.NewGuid(),
                            ProductId = productId,
                        };
                        newBasket.Product.Add(product);
                        basketContext.Baskets.Add(newBasket);

                        basketContext.SaveChanges();

                        return newBasket;
                    }
                }
                return null;
            }
            return null;
        }

    }
}
