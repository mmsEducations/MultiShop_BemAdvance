using AutoMapper;
using MultiShop.Data;
using MultiShop.Repository;

namespace MultiShop.Business
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public SliderService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public List<SliderDto> GetSliders()
        {
            List<Slider> result = _sliderRepository.GetAll();
            List<SliderDto> sliders = _mapper.Map<List<SliderDto>>(result);
            return sliders;
        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 