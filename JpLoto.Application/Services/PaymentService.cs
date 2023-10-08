using JpLoto.Application.Dto.Response;
using JpLoto.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace JpLoto.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly string secret;
    private readonly IIdentityService _identityService;
    private readonly IConfiguration _configuration;

    public PaymentService(IIdentityService identityService, IConfiguration configuration)
    {
        _identityService = identityService;
        _configuration = configuration;
        //StripeConfiguration.ApiKey = "sk_test_51JeEO9JabJVfdprGKFGEXs37nR7eB7WWs4eW1zH2S9Ld1vYe70QByz37l98mpiXcmxB2LbgKD0EucsjcLqDZqugM005UnKgDLn";
        StripeConfiguration.ApiKey = _configuration["Stripe:StripeSK"];
        secret = _configuration["Stripe:Secret"];
    }
    public async Task<Session> CreateCheckoutSession(string plan, int quantity, int price, string customerEmail, string imgUrl = "")
    {
        var key = StripeConfiguration.ApiKey;
        List<SessionLineItemOptions> lineItems = new List<SessionLineItemOptions>();
        lineItems.Add(new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmountDecimal = price * 100,
                Currency = "jpy",
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = plan,
                    Images = new List<string> { imgUrl }
                }
            },
            Quantity = quantity
        });

        var options = new SessionCreateOptions
        {
            CustomerEmail = customerEmail,
            ShippingAddressCollection = new SessionShippingAddressCollectionOptions { AllowedCountries = new List<string> { "JP" } },
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = lineItems,
            Mode = "payment",            
            SuccessUrl = _configuration["JplCors:ApiHost"] + "/order-success",
            CancelUrl = _configuration["JplCors:ApiHost"] + "/cancel-order"
        };

        var service = new SessionService();
        Session session = service.Create(options);
        return session;
    }

    /*
     * Received event with API version 2020-08-27, but Stripe.net 41.2.0 expects API version 2022-11-15. 
     * We recommend that you create a WebhookEndpoint with this API version. Otherwise, you can disable 
     * this exception by passing `throwOnApiVersionMismatch: false` to `Stripe.EventUtility.ParseEvent` or 
     * `Stripe.EventUtility.ConstructEvent`, but be wary that objects may be incorrectly deserialized.
     */
    public async Task<CheckoutResponse<bool>> FulFillOrder(HttpRequest request)
    {
        var json = await new StreamReader(request.Body).ReadToEndAsync();
        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    request.Headers["Stripe-Signature"],
                    secret,
                    throwOnApiVersionMismatch: false // Evita conflito de versoes de Stripe API
                );
            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                var session = stripeEvent.Data.Object as Session;
                var user = await _identityService.GetUserByEmailAsync(session.CustomerEmail);
            }
            return new CheckoutResponse<bool> { Data = true };
        }
        catch (StripeException e)
        {
            return new CheckoutResponse<bool> { Data = false, Success = false, Message = e.Message };
        }
    }
}
