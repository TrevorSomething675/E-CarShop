using E_CarShop.Core.ResponseModels;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        {
            CreateMap<Brand, BrandResponse>();
            CreateMap<Brand, BrandEntity>().ReverseMap();
        }
    }
}