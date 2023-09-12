﻿using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;

public class MiniLotoResultRepository : RepositoryBase<MiniLotoResult>, IMiniLotoResultRepository
{
    public MiniLotoResultRepository(DataContext dataContext) : base(dataContext) { }

}
