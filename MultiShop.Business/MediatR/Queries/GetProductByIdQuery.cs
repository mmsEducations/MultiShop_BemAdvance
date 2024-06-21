using MediatR;

namespace MultiShop.Business.MediatR.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }

    
}

