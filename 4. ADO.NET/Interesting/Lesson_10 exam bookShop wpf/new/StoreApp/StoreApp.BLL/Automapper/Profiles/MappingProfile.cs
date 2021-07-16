using AutoMapper;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Entities.PeopleInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.Automapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Seller, SellerDTO>();
            CreateMap<SellerDTO, Seller>();

            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            CreateMap<PublishingOffice, PublishingOfficeDTO>();
            CreateMap<PublishingOfficeDTO, PublishingOffice>();

            CreateMap<SoldBook, SoldBookDTO>();
            CreateMap<SoldBookDTO, SoldBook>();

            CreateMap<WroteOffBook, WroteOffBookDTO>();
            CreateMap<WroteOffBookDTO, WroteOffBook>();

            CreateMap<SetAsideBook, SetAsideBookDTO>();
            CreateMap<SetAsideBookDTO, SetAsideBook>();
        }
    }
}
