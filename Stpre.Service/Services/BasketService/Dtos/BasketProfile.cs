using AutoMapper;
using Store.Repository.Basket.Models;

namespace Store.Service.Services.BasketService.Dtos
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem,BasketItemDto>().ReverseMap();
        }
    }
}
