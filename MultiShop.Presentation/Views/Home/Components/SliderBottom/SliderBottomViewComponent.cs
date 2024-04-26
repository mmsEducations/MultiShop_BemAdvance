namespace MultiShop.Presentation.Views
{
    public class SliderBottomViewComponent(ISliderService sliderService) : ViewComponent
    {
        private readonly ISliderService _sliderService = sliderService;

        public IViewComponentResult Invoke()
        {
            List<SliderDto> sliders = _sliderService.GetSliders(SliderPosition.Bottom);

            return View(sliders);
        }
    }
}
