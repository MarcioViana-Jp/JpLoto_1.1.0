using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;

public class JplUserDetailRepository : RepositoryBase<JplUserDetail>, IJplUserDetailRepository
{
    public JplUserDetailRepository(DataContext dataContext) : base(dataContext) { }
}
