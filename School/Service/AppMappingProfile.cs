using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.ViewModels.LoginAndRegistration;


namespace School.Service
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<User, UserDb>().ReverseMap();
            CreateMap<User, LoginViewModel>().ReverseMap();
            CreateMap<User, RegisterViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, ConfirmEmailViewModel>().ReverseMap();
            CreateMap<User, ConfirmEmailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDb>().ReverseMap();
            CreateMap<CategoryDb, CategoryProductsViewModel>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Products, ProductsDb>().ReverseMap();
            CreateMap<Products, ListOfProductsViewModel>().ReverseMap();
            CreateMap<Products, ProductsPageViewModel>().ReverseMap();
            CreateMap<PictureProduct, PictureProductDb>().ReverseMap();
            CreateMap<PictureProduct, PictureProductsViewModel>().ReverseMap();

        }
    }
}
