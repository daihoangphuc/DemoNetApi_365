using AutoMapper;
using DemoNetApi.Application.Products.Commands;
using DemoNetApi.Application.Products.Queries;
using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;


namespace DemoNetApi.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                       .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                       .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription))
                       .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.Condition(src => src.ProductName != null))
                .ForMember(dest => dest.ProductDescription, opt => opt.Condition(src => src.ProductDescription != null))
                .ForMember(dest => dest.ProductPrice, opt => opt.Condition(src => src.ProductPrice != null));

            CreateMap<GetProductByIdQuery, Product>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<LoginUser, User>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.UserPassword));

            CreateMap<RegisterUser, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.UserPassword));

        }
    }
}
