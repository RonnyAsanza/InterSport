using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using InterSport.Domain.Models;
using AutoMapper;

namespace InterSport.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string ConvertBase64(string path)
        {
            string textBase64 = string.Empty;

            byte[] bytes = File.ReadAllBytes(path);
            textBase64 = Convert.ToBase64String(bytes);

            return textBase64;
        }

        public int CreateProduct(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            return _productRepository.CreateProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public bool EditProduct(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);

            return _productRepository.EditProduct(product);
        }

        public List<ProductViewModel> GetListProducts()
        {
            return _productRepository.GetListProducts();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        public int SaveImage(Image image)
        {
            return _productRepository.SaveImage(image);
        }

    }
}
