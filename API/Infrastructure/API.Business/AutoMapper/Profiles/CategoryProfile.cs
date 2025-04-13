using AutoMapper;

namespace API.Business.AutoMapper.Profiles
{
    using Features.CQRS.Commands.Category;
    using Model.Entities;
    using Features.CQRS.Results.Category;

    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<Category, GetCategoryQueryResult>();
        }
    }
}
