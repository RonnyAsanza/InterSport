using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Entities;
using InterSport.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterSport.Domain.Models;
using AutoMapper;

namespace InterSport.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public int CreateProduct(Product product)
        {
            using (var context = new InterSportContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product.ProductId;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var context = new InterSportContext())
            {
                var response = context.Database.ExecuteSqlCommand("delete top(1) from Products where ProductId = " + productId);
                if (response > 0) return true;
                return false;
            }
        }

        public bool EditProduct(Product product)
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var query = (from p in context.Products
                                 where p.ProductId == product.ProductId
                                 select p).FirstOrDefault();
                    if (query != null)
                    {
                        query.Description = product.Description;
                        query.Price = product.Price;
                        query.Stock = product.Stock;
                        query.IsActive = product.IsActive;
                        query.BrandId = product.BrandId;
                        query.CategoryId = product.CategoryId;
                        query.ImageId = product.ImageId;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<ProductViewModel> GetListProducts()
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    List<ProductViewModel> productViewModel = (from p in context.Products
                                                    join c in context.Categorys on p.CategoryId equals c.CategoryId
                                                    join b in context.Brands on p.BrandId equals b.BrandId
                                                    join i in context.Images on p.ImageId equals i.ImageId
                                                    into productV
                                                    from img in productV.DefaultIfEmpty()

                                                    select new ProductViewModel
                                                    {
                                                        ProductId = p.ProductId,
                                                        Name = p.Name,
                                                        Description = p.Description,
                                                        Price = p.Price,
                                                        Stock = p.Stock,
                                                        IsActive = p.IsActive,
                                                        BrandId = b.BrandId,
                                                        DescriptionB = b.Description,
                                                        CategoryId = c.CategoryId,
                                                        DescriptionC = c.Description,
                                                        ImageId = img.ImageId,
                                                        ImageName = img.ImageName,
                                                        ImagePath = img.ImagePath,
                                                        Base64 = img.Base64,
                                                        Extension = img.Extension
                                                    }).ToList();
                    return productViewModel;

                }
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }

        public Product GetProductById(int productId)
        {
            using (var context = new InterSportContext())
            {
                return context.Products.FirstOrDefault(p => p.ProductId == productId);
            }
        }

        public int SaveImage(Image image)
        {
            using (var context = new InterSportContext())
            {
                context.Images.Add(image);
                context.SaveChanges();
                return image.ImageId;
            }
        }

    }
}
