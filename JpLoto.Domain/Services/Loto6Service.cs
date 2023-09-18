using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class Loto6Service : ServiceBase<Loto6Result>, ILoto6ResultService
{
    public Loto6Service(ILoto6ResultRepository loto6Repository) : base(loto6Repository) { }
}