using AutoMapper;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.MapperProfile
{
    public class CategoryProfile : Profile
    {
        #region Constructor

        public CategoryProfile()
        {
            CreateMap<CategoryDto, ActionCategoryModel>().ReverseMap();
        }
        #endregion

       
    }
}
