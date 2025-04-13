using AutoMapper;

namespace API.Business.AutoMapper.Profiles
{
    using Features.CQRS.Commands.Product;
    using Model.Entities;
    using Features.CQRS.Results.Product;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<Product, GetProductQueryResult>();
        }
    }
}
