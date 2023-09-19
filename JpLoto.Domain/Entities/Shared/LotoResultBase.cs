using System.ComponentModel.DataAnnotations.Schema;

namespace JpLoto.Domain.Entities.Shared;

public abstract class LotoResultBase : Entity
{
    private readonly int _quantityBonus;
    public LotoResultBase(int quantityBonus)
    {
        _quantityBonus = quantityBonus;
    }
    public int DrawNumber {  get; set; }
    public DateTime Date { get; set; }
    public string? Numbers { get; set; } = string.Empty;
    public string? Bonus { get; set; } = string.Empty;
    [NotMapped]
    public bool Editing { get; set; } = false;
    [NotMapped]
    public bool IsNew { get; set; } = false;
    [NotMapped]
    public int QuantityBonus { get => _quantityBonus; }
}
