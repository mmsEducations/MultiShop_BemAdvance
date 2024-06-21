using MediatR;

namespace MultiShop.Business.MediatR.Queries
{
    public class GetSimilarProductsQuery : IRequest<List<ProductDto>>
    {
        public int Id { get; set; }
    }
}

