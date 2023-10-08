namespace JpLoto.Application.Dto.Request;

public class CheckoutRequest
{
    public string? Plan { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string? CustomerEmail { get; set; }
    public string? ImgUrl { get; set; }
}
