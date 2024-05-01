﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Data
{
    public class Product : BaseEntity, IOrdered, IImage
    {
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal DistcountedPrice { get; set; }
        public short? StockQuantity { get; set; }
        public int? Order { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }

    }
}
