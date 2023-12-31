﻿using JpLoto.Data.JplContext;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;

public class Loto6ResultRepository : RepositoryBase<Loto6Result>, ILoto6ResultRepository
{
    public Loto6ResultRepository(DataContext dataContext) : base(dataContext) { }

}
