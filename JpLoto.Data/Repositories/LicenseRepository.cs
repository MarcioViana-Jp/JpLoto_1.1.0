﻿using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;

public class LicenseRepository : RepositoryBase<Subscription>, ISubscriptionRepository
{
    public LicenseRepository(DataContext dataContext) : base(dataContext) { }
}
