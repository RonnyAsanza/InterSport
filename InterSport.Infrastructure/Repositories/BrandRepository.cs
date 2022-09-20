using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Entities;
using InterSport.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using InterSport.Domain.Models;

namespace InterSport.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public int CreateBrand(Brand brand)
        {
            using (var context = new InterSportContext())
            {
                context.Brands.Add(brand);
                context.SaveChanges();
                return brand.BrandId;
            }
        }

        public bool DeleteBrand(int brandId)
        {
            using (var context = new InterSportContext())
            {
                var delete = context.Database.ExecuteSqlCommand("delete top(1) from Brands where BrandId = " + brandId);
                if (delete > 0) return true;
                return false;
            }
        }

        public bool EditBrand(Brand brand)
        {
            using (var context = new InterSportContext())
            {
                var query = (from b in context.Brands
                             where b.BrandId == brand.BrandId
                             select b).FirstOrDefault();
                if (query != null)
                {
                    query.Description = brand.Description;
                    query.IsActive = brand.IsActive;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Brand GetBrandById(int brandId)
        {
            using (var context = new InterSportContext())
            {
                return context.Brands.FirstOrDefault(b => b.BrandId == brandId);
            }
        }

        public List<Brand> GetListBrands()
        {
            using (var context = new InterSportContext())
            {
                return context.Brands.ToList();
            }
        }

        public List<BrandViewModel> GetListBrandsByCategory(int categoryId)
        {
            using (var context = new InterSportContext())
            {
                var brands = (from b in context.Brands
                              join p in context.Products on b.BrandId equals p.BrandId
                              join c in context.Categorys on p.CategoryId equals c.CategoryId
                              where c.CategoryId == categoryId
                              select new BrandViewModel
                              {
                                  BrandId = b.BrandId,
                                  Description = b.Description,
                                  IsActive = b.IsActive
                              }).ToList();
                return brands;
            }
        }
    }
}
