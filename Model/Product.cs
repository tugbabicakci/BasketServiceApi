using System.Text.Json.Serialization;

namespace BasketService.Api.Model
{
    public class Product : BaseEntityModel
    {
        public string Title { get; set; }

        public string Brand { get; set; }

        public int PricePerUnit { get; set; }

        public int Total { get; set; }
    }
}
