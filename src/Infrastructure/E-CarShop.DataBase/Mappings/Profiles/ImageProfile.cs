using E_CarShop.Core.ReponseModels;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile() 
        {
            CreateMap<Image, ImageResponse>();
            CreateMap<Image, ImageEntity>().ReverseMap();
        }
    }
}