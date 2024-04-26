namespace MultiShop.Presentation.Views
{
    public class SliderLeftViewComponent(ISliderService sliderService) : ViewComponent
    {
        private readonly ISliderService _sliderService = sliderService;

        public IViewComponentResult Invoke()
        {
            List<SliderDto> sliders = _sliderService.GetSliders(SliderPosition.Left);

            return View(sliders);
        }
    }
}
