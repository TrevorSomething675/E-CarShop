using E_CarShop.Core.ReponseModels;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile() 
        {
            CreateMap<Notification,  NotificationResponse>();
            CreateMap<Notification, NotificationEntity>().ReverseMap();
        }
    }
}