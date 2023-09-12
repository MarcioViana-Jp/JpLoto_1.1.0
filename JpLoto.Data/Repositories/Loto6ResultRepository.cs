using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

public class Loto6ResultRepository : RepositoryBase<Loto6Result>, ILoto6ResultRepository
{
    public Loto6ResultRepository(DataContext dataContext) : base(dataContext) { }

}
