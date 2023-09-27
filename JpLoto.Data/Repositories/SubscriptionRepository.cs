using JpLoto.Data.JplContext;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;

public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(DataContext dataContext) : base(dataContext) { }
}
