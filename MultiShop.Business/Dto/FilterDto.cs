namespace MultiShop.Business.Dto
{
    public class FilterDto
    {
        public Sorting Sorting { get; set; }
        public int ShowingPageCount { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }

    public enum Sorting
    {
        Latest,
        Popularity,
        BestRating,
    }
}
