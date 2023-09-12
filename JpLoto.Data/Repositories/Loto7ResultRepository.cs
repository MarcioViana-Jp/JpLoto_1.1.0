﻿using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

public class Loto7ResultRepository : RepositoryBase<Loto7Result>, ILoto7ResultRepository
{
    public Loto7ResultRepository(DataContext dataContext) : base(dataContext) { }

}