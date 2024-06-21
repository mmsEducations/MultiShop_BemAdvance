
using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Presentation.Views
{
    public class CategoryViewComponent(IMediator mediator) : ViewComponent
    {
        private readonly IMediator _mediator = mediator;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new GetCategoriesQuery { };
            var categories = await _mediator.Send(query);

            return View(categories);
        }
    }
}
