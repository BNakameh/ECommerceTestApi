using AutoMapper;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Item;
using ECommerceTestApi.Models.OrderItem;

namespace ECommerceTestApi.MapperProfile
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemDto, GetAllOrderItemModel>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))

                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))

                .ForMember(dest => dest.OrderItemCount, opt => opt.MapFrom(src => src.Count))

                .ForMember(dest => dest.SerialNum, opt => opt.MapFrom(src => src.Order.SerialNum))

                .ForMember(dest => dest.SellPrice, opt => opt.MapFrom(src => src.Item.SellPrice))

                .ForMember(dest => dest.BuyPrice, opt => opt.MapFrom(src => src.Item.BuyPrice))

                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.Item.Count));
        }
    }
}
