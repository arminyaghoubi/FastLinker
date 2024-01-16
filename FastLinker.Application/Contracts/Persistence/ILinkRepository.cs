using FastLinker.Domain;

namespace FastLinker.Application.Contracts.Persistence;

public interface ILinkRepository
{
    Task<Link?> GetLinkByUrlAsync(string url);
    Task<Link?> GetLinkByShortKeyAsync(string shortKey);
    Task CreateLinkAsync(Link link);
}
