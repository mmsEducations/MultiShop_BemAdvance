using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Business.MediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdSync(request.Id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
