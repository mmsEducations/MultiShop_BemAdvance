﻿using Microsoft.EntityFrameworkCore;

namespace MultiShop.Data
{
    public class MultiShopDbContext : DbContext
    {

        //new DbContextOptions<DbContext>()
        public MultiShopDbContext(DbContextOptions<MultiShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; } //Database objesine karşılık gelir 
    }
}
