using Microsoft.AspNetCore.Http;
using Stripe.Checkout;
using JpLoto.Application.Dto.Response;

namespace JpLoto.Application.Interfaces;

public interface IPaymentService
{
    Task<Session> CreateCheckoutSession(string plan, int quantity, int price, string customerEmail, string imgUrl);
    Task<CheckoutResponse<bool>> FulFillOrder(HttpRequest request);
}
