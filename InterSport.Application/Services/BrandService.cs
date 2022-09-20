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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public int CreateBrand(Brand brand)
        {
            return _brandRepository.CreateBrand(brand);
        }

        public bool DeleteBrand(int brandId)
        {
            return _brandRepository.DeleteBrand(brandId);
        }

        public bool EditBrand(Brand brand)
        {
            return _brandRepository.EditBrand(brand);
        }

        public Brand GetBrandById(int brandId)
        {
            return _brandRepository.GetBrandById(brandId);
        }

        public List<Brand> GetListBrands()
        {
            return _brandRepository.GetListBrands();
        }

        public List<Brand> GetListBrandsByCategory(int categoryId)
        {
            var brandViewModel = _brandRepository.GetListBrandsByCategory(categoryId);
            var brands = Mapper.Map<List<Brand>>(brandViewModel);

            return brands;

        }
    }
}
