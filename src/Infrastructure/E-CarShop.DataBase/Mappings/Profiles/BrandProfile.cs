using AutoMapper;
using E_CarShop.Core.Models;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        {
            CreateMap<Car, CarEntity>().ReverseMap();
        }
    }
}
