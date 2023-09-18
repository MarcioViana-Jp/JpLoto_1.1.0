using JpLoto.Lottery.Shared;
using System.Text.Json.Serialization;

namespace JpLoto.Lottery.Dto;

public class Jogo
{
    public int Id { get; set; }
    public string DezenasTexto { get; set; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public int[] Dezenas { get => LotoBase.TextoParaVetor(DezenasTexto, 99).DezenasVetor; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public bool IsDeleted { get; set; } = false;
}
