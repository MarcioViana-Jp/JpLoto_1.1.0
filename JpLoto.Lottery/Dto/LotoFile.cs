using JpLoto.Lottery.Loto;

namespace JpLoto.Lottery.Dto;

public class LotoFile
{
    public string LotoType { get; set; } = string.Empty;
    public string SelectedNumbers { get; set; } = string.Empty;
    public string FixedNumbers { get; set; } = string.Empty;
    public List<Card> Combinations { get; set; } = new();
}
