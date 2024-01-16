using FastLinker.Domain;

namespace FastLinker.Application.Contracts.Persistence;

public interface IShortLinkRepository
{
    Task<ShortLink?> GetShortLinkByTitleAsync(string title);
    Task CreateShortLinkAsync(ShortLink shortLink);
}
