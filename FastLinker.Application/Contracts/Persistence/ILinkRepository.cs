using FastLinker.Domain;

namespace FastLinker.Application.Contracts.Persistence;

public interface ILinkRepository
{
    Task<Link?> GetLinkByUrlAsync(string url);
    Task CreateLinkAsync(Link link);
}
