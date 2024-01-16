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

    public async Task<ShortLink?> GetShortLinkByTitleAsync(string title)
    {
        return await _context.ShortLinks.FirstOrDefaultAsync(s => s.Title == title);
    }
}