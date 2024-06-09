﻿using Sieve.Attributes;

namespace MultiShop.Data
{
    public class Product : BaseEntity, IOrdered, IImage
    {
        public int ProductID { get; set; }

        [Sieve(CanFilter = true)]
        public required string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal DistcountedPrice { get; set; }
        public short? StockQuantity { get; set; }
        public int? Order { get; set; }
        public string? Image { get; set; }

        [Sieve(CanFilter = true)]
        public string? Description { get; set; }

        [Sieve(CanFilter = true)]
        public int CategoryID { get; set; }
        public Category Category { get; set; }//Navigation property
        public ICollection<ProductRating> ProductRatings { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
//İlişki kurmak için 3 farklı yöntem  var 
//Default convention 
//Attribute
//OnModel Creating tarafında yapmak 