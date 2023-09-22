namespace JpLoto.Site.Interfaces.Repositories;

public interface IAccountUserDetailRepository : IUserDetailRepository
{
    event Action? OnChange;
}
