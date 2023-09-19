using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories.Shared;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class LicenseHistoryService : ServiceBase<LicenseHistory>, ILicenseHistoryService
{
    public LicenseHistoryService(IRepositoryBase<LicenseHistory> licenceHistoryRepository) : base(licenceHistoryRepository) { }
}
