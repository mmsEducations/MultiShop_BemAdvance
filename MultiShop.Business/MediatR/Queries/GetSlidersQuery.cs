using MediatR;

namespace MultiShop.Business.MediatR.Queries
{
    public class GetSlidersQuery : IRequest<List<SliderDto>>
    {
        public SliderPosition SliderPosition { get; set; }
    }
}

