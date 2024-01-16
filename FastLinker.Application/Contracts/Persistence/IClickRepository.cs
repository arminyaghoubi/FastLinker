using FastLinker.Domain;

namespace FastLinker.Application.Contracts.Persistence;

public interface IClickRepository
{
    Task<Click?> GetClickByIpAndShortKeyAsync(string ip, int shortLinkId);
    Task CreateClickAsync(Click click);
}