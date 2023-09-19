using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class JplUserDetailService : ServiceBase<JplUserDetail>, IJplUserDetailService
{
    public JplUserDetailService(IJplUserDetailRepository jplUserDetailRepository) : base(jplUserDetailRepository) { }
}
