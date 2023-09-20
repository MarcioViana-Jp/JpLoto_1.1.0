using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class Trial : Entity
{
    public string UserId { get; set; }
    public DateTime TrialBegin { get; set; }
    public DateTime TrialFinish { get; set; }

    public Trial(string userId, DateTime trialBegin, DateTime trialFinish)
        : this(default, userId, trialBegin, trialFinish)
    {
    }

    public Trial(int id, string userId, DateTime trialBegin, DateTime trialFinish)
    {
        Id = id;
        UserId = userId;
        TrialBegin = trialBegin;
        TrialFinish = trialFinish;
    }
}
