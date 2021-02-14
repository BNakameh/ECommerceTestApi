using AutoMapper;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Item;

namespace ECommerceTestApi.MapperProfile
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDto, ActionItemModel>().ReverseMap();

            CreateMap<ItemDto, GetItem>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new GetLastLevelCategory()
                {
                    Id = src.Category.Id,
                    Name = src.Category.Name
                }));
        }
    }
}
