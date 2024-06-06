using Microsoft.EntityFrameworkCore;

namespace MultiShop.Data
{
    public class MultiShopDbContext : DbContext
    {

        //new DbContextOptions<DbContext>()
        public MultiShopDbContext(DbContextOptions<MultiShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; } //Database objesine karşılık gelir 
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.ProductID });
        }
    }


}
