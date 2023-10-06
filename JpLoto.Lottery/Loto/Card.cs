using JpLoto.Lottery.Loto.Shared;
using System.Text.Json.Serialization;

namespace JpLoto.Lottery.Loto;

public class Card
{
    public int Id { get; set; }
    public string NumbersText { get; set; } = string.Empty;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public bool IsDeleted { get; set; } = false;
    public int[] Numbers(int lotoType) => 
        LotoBase.TextToArray(NumbersText, lotoType);

}
