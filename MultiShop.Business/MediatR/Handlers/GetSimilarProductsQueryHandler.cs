using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Business.MediatR.Handlers
{
    public class GetSimilarProductsQueryHandler : IRequestHandler<GetSimilarProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetSimilarProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetSimilarProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdSync(request.Id);

            var similarProducts = await _productRepository.GetProductsByCategoriIdAsync(product.Category.CategoryId);
            List<ProductDto> similarProductDtos = _mapper.Map<List<ProductDto>>(similarProducts.Take(10).ToList());
            return similarProductDtos;
        }
    }
}
