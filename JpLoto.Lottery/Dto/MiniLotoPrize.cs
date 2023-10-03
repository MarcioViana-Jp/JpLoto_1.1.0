using JpLoto.Lottery.Loto;

namespace JpLoto.Lottery.Dto;

public class MiniLotoPrize
{
    public record Prize
    {
        public Card? Card { get; set; }
        public string? CardPosition { get; set; }
    }

    public List<Prize>? WinningCards1 { get; set; } = new();
    public List<Prize>? WinningCards2 { get; set; } = new();
    public List<Prize>? WinningCards3 { get; set; } = new();
    public List<Prize>? WinningCards4 { get; set; } = new();
}
