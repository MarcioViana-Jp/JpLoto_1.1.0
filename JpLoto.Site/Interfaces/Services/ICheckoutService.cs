using JpLoto.Application.Dto.Request;

namespace JpLoto.Site.Interfaces.Services;

public interface ICheckoutService
{
    Task<string> PlaceOrder(CheckoutRequest request);
}