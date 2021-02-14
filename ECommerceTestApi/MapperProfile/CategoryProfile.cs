using AutoMapper;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Category;
using System.Linq;

namespace ECommerceTestApi.MapperProfile
{
    public class CategoryProfile : Profile
    {
        #region Constructor

        public CategoryProfile()
        {
            CreateMap<CategoryDto, ActionCategoryModel>().ReverseMap();

            CreateMap<CategoryDto, GetCategoryModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.ToList()));
        }
        #endregion


    }
}
