using FastLinker.Domain;

namespace FastLinker.Application.Contracts.Persistence;

public interface IShortLinkRepository
{
    Task<ShortLink?> GetShortLinkByTitleAndUrlAsync(string title,int url);
    Task CreateShortLinkAsync(ShortLink shortLink);
}
