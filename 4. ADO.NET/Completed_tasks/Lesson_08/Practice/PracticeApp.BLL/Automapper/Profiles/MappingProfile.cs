using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PracticeApp.BLL.DTO;
using PracticeApp.DAL.Entities;

namespace PracticeApp.BLL.Automapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
