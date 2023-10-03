using JpLoto.Lottery.Loto;

namespace JpLoto.Lottery.Dto;

public class LotoResponse
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public List<Card> Combinations { get; set; } = new();
}
