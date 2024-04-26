
namespace MultiShop.Business
{
    public class SliderService(ISliderRepository sliderRepository, IMapper mapper) : ISliderService
    {
        private readonly ISliderRepository _sliderRepository = sliderRepository;
        private readonly IMapper _mapper = mapper;

        public List<SliderDto> GetSliders(SliderPosition sliderPosition)
        {
            List<Slider> result = [];
            if (sliderPosition == SliderPosition.Left)
            {
                result = _sliderRepository.GetAll().Where(x => x.SliderPosition == (int)SliderPosition.Left).Take(3).ToList();
            }
            if (sliderPosition == SliderPosition.Right)
            {
                result = _sliderRepository.GetAll().Where(x => x.SliderPosition == (int)SliderPosition.Right).Take(2).ToList();

            }
            if (sliderPosition == SliderPosition.Bottom)
            {
                result = _sliderRepository.GetAll().Where(x => x.SliderPosition == (int)SliderPosition.Bottom).Take(2).ToList();

            }

            List<SliderDto> sliders = _mapper.Map<List<SliderDto>>(result);
            return sliders;
        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 