using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class MiniLotoResultService : ServiceBase<MiniLotoResult>, IMiniLotoResultService
{
    public MiniLotoResultService(IMiniLotoResultRepository minilotoRepository) : base(minilotoRepository) { }
}