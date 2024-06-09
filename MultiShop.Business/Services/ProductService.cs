﻿using MultiShop.Business.Dto;
using Sieve.Models;
using Sieve.Services;

namespace MultiShop.Business
{
    public class ProductService(IProductRepository productRepository,
                                IMapper mapper,
                                ISieveProcessor sieveProcessor
                                ) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ISieveProcessor _sieveProcessor = sieveProcessor;

        public ProductDto GetProductById(int id)
        {
            Product product = _productRepository.GetProductById(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            productDto.ProductRating = (product != null) ? Convert.ToInt32(product.ProductRatings.Average(p => p.Rating)) : 0;

            return productDto;
        }

        public List<ProductDto> GetProducts()
        {
            List<Product> products = _productRepository.GetAll();
            List<ProductDto> productsDtos = _mapper.Map<List<ProductDto>>(products);
            return productsDtos;

        }

        public List<ProductDto> GetSimilarProducts(int id)
        {
            var catId = _productRepository.GetProductById(id).Category.CategoryId;
            List<Product> products = _productRepository.GetAll(p => p.CategoryID == catId)
                                                       .Take(10)
                                                       .ToList();
            List<ProductDto> productsDtos = _mapper.Map<List<ProductDto>>(products);
            return productsDtos;
        }

        public List<ProductDto> GetProductsByCategoriId(int id)
        {
            List<Product> products = _productRepository.GetProductsByCategoriId(id);
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        public List<ProductDto> GetProductsByFilter(FilterDto filter)
        {
            List<Product> products = _productRepository.GetProductsByFilter(filter.MinPrice, filter.MaxPrice, filter.ShowingPageCount);
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        public List<ProductDto> GetProductsWithSieve(SieveModel sieveModel)
        {
            IQueryable<Product> products = _productRepository.GetAllProductsWithCategory().AsQueryable();

            var productSiveResult = _sieveProcessor.Apply<Product>(sieveModel, products).ToList();
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(productSiveResult);

            return productDtos;
        }

    }
}

//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 