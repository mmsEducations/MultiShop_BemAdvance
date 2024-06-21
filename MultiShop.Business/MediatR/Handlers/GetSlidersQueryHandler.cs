using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Business.MediatR.Handlers
{
    public class GetSlidersQueryHandler : IRequestHandler<GetSlidersQuery, List<SliderDto>>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public GetSlidersQueryHandler(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }
        public async Task<List<SliderDto>> Handle(GetSlidersQuery request, CancellationToken cancellationToken)
        {

            List<Slider> result = await _sliderRepository.GetAllAsync();

            if (request.SliderPosition == SliderPosition.Left)
            {
                result = result.Where(x => x.SliderPosition == (int)SliderPosition.Left).Take(3).ToList();
            }
            if (request.SliderPosition == SliderPosition.Right)
            {
                result = result.Where(x => x.SliderPosition == (int)SliderPosition.Right).Take(2).ToList();
            }
            if (request.SliderPosition == SliderPosition.Bottom)
            {
                result = result.Where(x => x.SliderPosition == (int)SliderPosition.Bottom).Take(2).ToList();
            }

            List<SliderDto> sliders = _mapper.Map<List<SliderDto>>(result);
            return sliders;
        }
    }
}
