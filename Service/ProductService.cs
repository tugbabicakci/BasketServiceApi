using BasketService.Api.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketService.Api.Service
{
    public class ProductService
    {
        private readonly BasketContext _basketContext;

        public ProductService(BasketContext basketContext)
        {
            _basketContext = basketContext;

            if (basketContext.Products.Count() == 0)
            {
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });
                _basketContext.Products.Add(new Product { Brand = "Kadın", PricePerUnit = 20, Title = "Elbise" });

                _basketContext.SaveChanges();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return _basketContext.Products.ToList();
        }

        public async Task<Product> Get(int id)
        {
            return await _basketContext.Products.FindAsync(id);
        }
    }
}
