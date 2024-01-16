using FastLinker.Application.Contracts.Persistence;
using FastLinker.Domain;
using FastLinker.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace FastLinker.Persistence.Repositories;

public class LinkRepository : ILinkRepository
{
    private readonly FastLinkerContext _context;

    public LinkRepository(FastLinkerContext context)
    {
        _context = context;
    }

    public async Task CreateLinkAsync(Link link)
    {
        await _context.Links.AddAsync(link);
        await _context.SaveChangesAsync();
    }

    public async Task<Link?> GetLinkByUrlAsync(string url)
    {
        return await _context.Links.FirstOrDefaultAsync(l => l.Url == url);
    }
}
