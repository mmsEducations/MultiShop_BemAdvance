using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Business.MediatR.Handlers
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductByCategoryIdQuery, List<ProductDto>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsByCategoryIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository.GetProductsByCategoriIdAsync(request.Id);
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }
    }
}
