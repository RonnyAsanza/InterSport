using InterSport.Domain.Entities;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        int CreateBrand(Brand brand);
        Brand GetBrandById(int brandId);
        bool DeleteBrand(int brandId);
        bool EditBrand(Brand brand);
        List<Brand> GetListBrands();
        List<BrandViewModel> GetListBrandsByCategory(int categoryId);
    }
}
