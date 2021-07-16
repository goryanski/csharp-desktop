using AutoMapper;
using StoreApp.BLL.DTO;
using StoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.Automapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();//.ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
