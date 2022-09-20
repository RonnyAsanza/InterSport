using InterSport.Domain.Entities;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Services
{
    public interface IBrandService
    {
        int CreateBrand(Brand brand);
        Brand GetBrandById(int brandId);
        bool DeleteBrand(int brandId);
        bool EditBrand(Brand brand);
        List<Brand> GetListBrands();
        List<Brand> GetListBrandsByCategory(int categoryId);

    }
}
