using AutoMapper;
using InterSport.Domain.Entities;
using InterSport.Domain.Models;

namespace InterSport.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductViewModel>().ReverseMap();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
        }
    }
}
