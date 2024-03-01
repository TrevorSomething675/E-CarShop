using E_CarShop.Core.ReponseModels;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<Role, RoleResponse>();
            CreateMap<Role, RoleEntity>().ReverseMap();
        }
    }
}