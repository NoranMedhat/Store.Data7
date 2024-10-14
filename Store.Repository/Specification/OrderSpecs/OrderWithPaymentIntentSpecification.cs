using Store.Data.Entities.OrderEntities;

namespace Store.Repository.Specification.OrderSpecs
{
    public class OrderWithPaymentIntentSpecification : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentSpecification(string? paymentIntentId) 
            : base(order=>order.PaymentIntentId==paymentIntentId)
        {
        }
    }
}
