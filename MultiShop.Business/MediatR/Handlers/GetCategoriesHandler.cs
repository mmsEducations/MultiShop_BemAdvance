using MediatR;
using MultiShop.Business.MediatR.Queries; // Namespace'ini uygun şekilde değiştirin

namespace MultiShop.Business.MediatR.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            List<CategoryDto> categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }
    }
}
