using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Basket.Models;
using Store.Service.Services.PaymentService;
using Stripe;

namespace Store.Web.Controllers
{
    
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;
        const string EndpointSecret = "whsec_6ab51ed27c173edc0c9e38e517c369c546b4da87d351fdc597d9972cca2453a6";

        public PaymentController(IPaymentService paymentService,
            ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(CustomerBasketDto input)
            => Ok(await _paymentService.CreateOrUpdatePaymentIntent(input));
        [HttpPost]
        public async Task<ActionResult> webhook()
        {
            var json= await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers[""], EndpointSecret);
                PaymentIntent paymentIntent;
                if (stripeEvent.Type == "payment_intent.payment_failed")  
                {
                    paymentIntent=stripeEvent.Data.Object as PaymentIntent;
                    _logger.LogInformation("Payment Failed :",paymentIntent.Id);
                    var order =await _paymentService.UpdateOrderPaymentFailed(paymentIntent.Id);
                    _logger.LogInformation("Order Update to Payment Failed :", order.Id);

                }
                else if (stripeEvent.Type == "payment_intent.succeeded") 
                {
                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    _logger.LogInformation("Payment succeeded :", paymentIntent.Id);
                    var order = await _paymentService.UpdateOrderPaymentSucceeded(paymentIntent.Id);
                    _logger.LogInformation("Order Update to Payment succeeded :", order.Id);
                }
                else if (stripeEvent.Type == "payment_intent.created") 
                {
                    _logger.LogInformation("Payment created");

                }
                else 
                {
                    Console.WriteLine("unhandeled event type{0}",stripeEvent.Type);
                }
                return Ok();



            }
            catch (StripeException e)
            {
                return BadRequest();
                
            }
        }
    }
}
