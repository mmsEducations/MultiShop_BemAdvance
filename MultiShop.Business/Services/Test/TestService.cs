using MultiShop.Business.Interfaces.Test;

namespace MultiShop.Business.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<Product> _productRepository;

        public TestService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void ExampleTransaction()
        {
            using (var transaction = _productRepository.BeginTransaction())
            {
                try
                {
                    // Burada işlemleri gerçekleştirirken bir hata olursa, işlem geri alınacak
                    var newProduct1 = new Product { ProductName = "Example Product 1", Price = 10 };
                    var newProduct2 = new Product { ProductName = "Example Product 2", Price = 20 };

                    _productRepository.Add(newProduct1);
                    _productRepository.Add(newProduct2);

                    // Başka işlemler...

                    transaction.Commit(); // İşlemler başarıyla gerçekleşirse, transaction'ı kaydet
                }
                catch (Exception ex)
                {
                    // Hata durumunda işlemleri geri al
                    transaction.Rollback();
                    throw; // Hatanın yukarıya fırlatılması
                }
            }
        }
    }
}



