namespace MultiShop.Business
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string? Image { get; set; }
        public int? Order { get; set; }

        public string CatIdAndName { get; set; }

        public string ParentCategoryIdAndName { get; set; }

        public int ProductCount { get; set; }

    }
}
