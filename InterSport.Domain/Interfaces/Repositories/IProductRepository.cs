using InterSport.Domain.Entities;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        int CreateProduct(Product product);
        Product GetProductById(int productId);
        bool DeleteProduct(int productId);
        bool EditProduct(Product product);
        List<ProductViewModel> GetListProducts();
        int SaveImage(Image image);
    }
}
