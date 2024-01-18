using FastLinker.Application.Contracts.Persistence;
using FastLinker.Domain;
using FastLinker.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace FastLinker.Persistence.Repositories;

public class ClickRepository : IClickRepository
{
    private readonly FastLinkerContext _context;

    public ClickRepository(FastLinkerContext context)
    {
        _context = context;
    }

    public async Task CreateClickAsync(Click click)
    {
        await _context.AddAsync(click);
        await _context.SaveChangesAsync();
    }

    public async Task<Click?> GetClickByIpAndShortKeyAsync(string ip, int shortLinkId)
    {
        return await _context.Clicks.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Ip == ip && c.ShortLinkId == shortLinkId);
    }
}