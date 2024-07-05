using AutoMapper;
using DemoNetApi.Application.Products.Commands;
using DemoNetApi.Application.Products.Queries;
using DemoNetApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            CreateMap<GetProductByIdQuery, Product>();

        }
    }
}
