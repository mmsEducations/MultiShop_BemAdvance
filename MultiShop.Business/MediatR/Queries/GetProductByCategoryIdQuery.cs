using MediatR;

namespace MultiShop.Business.MediatR.Queries
{
    public class GetProductByCategoryIdQuery : IRequest<List<ProductDto>>
    {
        public int Id { get; set; }
    }


}

