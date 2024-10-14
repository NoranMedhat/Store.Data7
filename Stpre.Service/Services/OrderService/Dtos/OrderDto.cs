using System.ComponentModel.DataAnnotations;

namespace Store.Service.Services.OrderService.Dtos
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public string BuyerEmail { get; set; }
        [Required]
        public int DeliveryMethodId { get; set; }
        public AddresDto ShippingAdress { get; set; }
    }
}
