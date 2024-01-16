using FastLinker.Domain;

namespace FastLinker.Application.Contracts.Persistence;

public interface IShortLinkRepository
{
    Task<ShortLink?> GetShortLinkByTitleAndUrlAsync(string title,int url);
    Task<ShortLink?> GetShortLinkByShortKeyAsync(string shortKey);
    Task CreateShortLinkAsync(ShortLink shortLink);
}
