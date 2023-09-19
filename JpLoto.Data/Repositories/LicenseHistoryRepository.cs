using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;

namespace JpLoto.Data.Repositories;

public class LicenseHistoryRepository : RepositoryBase<JplLicenseHistory>, ILicenseHistoryRepository
{
    public LicenseHistoryRepository(DataContext dataContext) : base(dataContext) { }
}
