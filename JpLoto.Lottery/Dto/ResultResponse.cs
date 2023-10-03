namespace JpLoto.Lottery.Dto;

public class ResultResponse<TResult, TPrize>
{
    public bool Success { get => Errors?.Count() == 0; }
    public TResult? Result { get; set; }
    public TPrize? Prizes { get; set; }

    public List<string>? Errors { get; set; } = new();
}
