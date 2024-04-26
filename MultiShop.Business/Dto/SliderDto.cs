namespace MultiShop.Business
{
    public class SliderDto
    {
        public int Id { get; set; }
        public required string Header { get; set; }
        public required string Content { get; set; }
        public required string Image { get; set; }
        public int SliderPosition { get; set; }
        public int? Order { get; set; }
    }
}
