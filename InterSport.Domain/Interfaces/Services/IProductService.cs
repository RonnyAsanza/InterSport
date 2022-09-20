using InterSport.Domain.Entities;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Services
{
    public interface IProductService
    {
        int CreateProduct(ProductViewModel product);
        Product GetProductById(int productId);
        bool DeleteProduct(int productId);
        bool EditProduct(ProductViewModel product);
        List<ProductViewModel> GetListProducts();
        string ConvertBase64(string path);
        int SaveImage(Image image);
    }
}
