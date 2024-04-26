namespace MultiShop.Presentation.Views
{
    public class SliderRightViewComponent(ISliderService sliderService) : ViewComponent
    {
        private readonly ISliderService _sliderService = sliderService;

        public IViewComponentResult Invoke()
        {
            List<SliderDto> sliders = _sliderService.GetSliders(SliderPosition.Right);
            return View(sliders);
        }
    }
}
