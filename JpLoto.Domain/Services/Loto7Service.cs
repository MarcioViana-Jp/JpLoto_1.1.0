using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class Loto7Service : ServiceBase<Loto7Result>, ILoto7ResultService
{
    public Loto7Service(ILoto7ResultRepository loto7Repository) : base(loto7Repository) { }
}