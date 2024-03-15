using E_CarShop.Core.ResponseModels;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserResponse>();
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}