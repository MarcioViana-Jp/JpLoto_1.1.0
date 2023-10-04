using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto;

public class TrialDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime TrialBegin { get; set; }
    public DateTime TrialFinish { get; set; }

    public TrialDto(string userId, DateTime trialBegin, DateTime trialFinish)
    {
        Id = 0;
        UserId = userId ?? string.Empty;
        TrialBegin = trialBegin;
        TrialFinish = trialFinish;
    }
    public TrialDto(int id, string userId, DateTime trialBegin, DateTime trialFinish)
    {
        Id = id;
        UserId = userId ?? string.Empty;
        TrialBegin = trialBegin;
        TrialFinish = trialFinish;
    }
    public TrialDto(Trial trial)
    {
        Id = trial.Id;
        UserId = trial.UserId;
        TrialBegin = trial.TrialBegin;
        TrialFinish = trial.TrialFinish;
    }
    public static Trial ConvertToEntity(TrialDto dto)
    {
        return new Trial
        (
            dto.UserId,
            dto.TrialBegin,
            dto.TrialFinish
        );
    }
}
