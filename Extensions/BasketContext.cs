using BasketService.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketService.Api.Service
{
    public class BasketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public BasketContext(DbContextOptions<BasketContext> options)
            : base(options)
        {
        }

    }
}
