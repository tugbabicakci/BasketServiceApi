using System;
using System.Collections.Generic;

namespace BasketService.Api.Model
{
    public class Basket : BaseEntityModel
    {
        public int ProductId { get; set; }

        public Guid UserId { get; set; }

        public List<Product> Product { get; set; } = new List<Product>();
    }
}
