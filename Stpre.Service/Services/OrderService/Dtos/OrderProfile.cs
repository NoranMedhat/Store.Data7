using AutoMapper;
using Store.Data.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderService.Dtos
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress, AddresDto>().ReverseMap();
            CreateMap<Order, OrderDetailsDto>()
                .ForMember(dest => dest.DeliveryMethodName, option => option.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.ShippingPrice, option => option.MapFrom(src => src.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
         .ForMember(dest => dest.ProductItemId, option => option.MapFrom(src => src.ProductItem.ProductId))
         .ForMember(dest => dest.ProductItemName, option => option.MapFrom(src => src.ProductItem.ProductName))
         .ForMember(dest => dest.PictureUrl, option => option.MapFrom(src => src.ProductItem.PictureUrl))
         .ForMember(dest => dest.PictureUrl, option => option.MapFrom<OrderItemPictureUrlResolver>()).ReverseMap();
            



        }
    }
}
