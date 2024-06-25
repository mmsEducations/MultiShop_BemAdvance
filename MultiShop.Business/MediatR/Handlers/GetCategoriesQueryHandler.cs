using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Business.MediatR.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAllAsync();
            List<CategoryDto> categoriDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriDtos;

        }
    }
}
