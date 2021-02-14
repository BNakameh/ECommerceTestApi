using AutoMapper;
using ECommerceTestApi.Infrastructure.DataModel;
using ECommerceTestApi.Models.Order;
using System.Linq;

namespace ECommerceTestApi.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, ActionOrderModel>().ReverseMap();

            CreateMap<OrderDto, GetAllOrderModel>().ReverseMap();

            CreateMap<OrderDto, GetAllOrderModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsDeleted ? "Canceled" : "Created"));

            CreateMap<OrderDto, GetOrderModel>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems.ToList()));
        }
    }
}
