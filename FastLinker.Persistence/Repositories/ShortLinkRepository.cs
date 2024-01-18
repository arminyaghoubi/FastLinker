using FastLinker.Application.Contracts.Persistence;
using FastLinker.Domain;
using FastLinker.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace FastLinker.Persistence.Repositories;

public class ShortLinkRepository : IShortLinkRepository
{
    private readonly FastLinkerContext _context;

    public ShortLinkRepository(FastLinkerContext context)
    {
        _context = context;
    }

    public async Task CreateShortLinkAsync(ShortLink shortLink)
    {
        await _context.AddAsync(shortLink);
        await _context.SaveChangesAsync();
    }

    public async Task<ShortLink?> GetShortLinkByShortKeyAsync(string shortKey)
    {
        return await _context.ShortLinks.AsNoTracking()
            .FirstOrDefaultAsync(s => s.ShortKey == shortKey);
    }

    public async Task<ShortLink?> GetShortLinkByTitleAndUrlAsync(string title, int linkId)
    {
        return await _context.ShortLinks.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Title == title && s.LinkId == linkId);
    }
}
