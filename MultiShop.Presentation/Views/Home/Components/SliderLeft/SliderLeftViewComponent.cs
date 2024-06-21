using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Presentation.Views
{
    public class SliderLeftViewComponent(IMediator mediator) : ViewComponent
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new GetSlidersQuery { SliderPosition = SliderPosition.Left };
            var sliders = await _mediator.Send(query);

            return View(sliders);
        }
    }
}
