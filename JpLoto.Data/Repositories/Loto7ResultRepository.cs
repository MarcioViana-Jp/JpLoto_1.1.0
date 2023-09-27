using JpLoto.Data.JplContext;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;
public class Loto7ResultRepository : RepositoryBase<Loto7Result>, ILoto7ResultRepository
{
    public Loto7ResultRepository(DataContext dataContext) : base(dataContext) { }

}
