using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto;

public class TrialDto
{
    public string UserId { get; set; } = string.Empty;
    public DateTime TrialBegin { get; set; }
    public DateTime TrialFinish { get; set; }

    public TrialDto(string userId, DateTime trialBegin, DateTime trialFinish)
    {
        userId = userId ?? string.Empty;
        TrialBegin = trialBegin;
        TrialFinish = trialFinish;
    }

    public static TrialDto ConvertToDto(Trial trial)
    {
        return new TrialDto
        (
            trial.UserId,
            trial.TrialBegin,
            trial.TrialFinish
        );
    }
}
