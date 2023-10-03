using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class MiniLotoResult : LotoResultBase
{
    public int Prize1Value { get; set; }
    public int Prize2Value { get; set; }
    public int Prize3Value { get; set; }
    public int Prize4Value { get; set; }
    public MiniLotoResult() : base(1) { }
}
