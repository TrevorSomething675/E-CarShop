﻿using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.RequestModels;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Mappings.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarRequest, Car>();
            CreateMap<Car, CarResponse>();
            CreateMap<Car, CarEntity>().ReverseMap();
        }
    }
}