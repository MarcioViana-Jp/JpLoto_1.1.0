using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class Loto7Result : LotoResultBase
{
    public int Prize1Value { get; set; }
    public int Prize2Value { get; set; }
    public int Prize3Value { get; set; }
    public int Prize4Value { get; set; }
    public int Prize5Value { get; set; }
    public int Prize6Value { get; set; }
    public Loto7Result() : base(2) { }
}
