using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class Loto6Result : LotoResultBase
{
    public int Prize1Value { get; set; }
    public int Prize2Value { get; set; }
    public int Prize3Value { get; set; }
    public int Prize4Value { get; set; }
    public int Prize5Value { get; set; }
    public Loto6Result() : base(1) { }
}
