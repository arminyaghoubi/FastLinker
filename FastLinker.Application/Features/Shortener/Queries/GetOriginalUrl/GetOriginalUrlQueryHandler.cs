using FastLinker.Application.Contracts.Persistence;
using FastLinker.Application.Exceptions;
using FastLinker.Domain;
using MediatR;

namespace FastLinker.Application.Features.Shortener.Queries.GetOriginalUrl;

public class GetOriginalUrlQueryHandler : IRequestHandler<GetOriginalUrlQuery, GetOriginalUrlDto>
{
    private readonly ILinkRepository _linkRepository;
    private readonly IClickRepository _clickRepository;
    private readonly IShortLinkRepository _shortLinkRepository;

    public GetOriginalUrlQueryHandler(ILinkRepository linkRepository,
        IClickRepository clickRepository,
        IShortLinkRepository shortLinkRepository)
    {
        _linkRepository = linkRepository;
        _clickRepository = clickRepository;
        _shortLinkRepository = shortLinkRepository;
    }

    public async Task<GetOriginalUrlDto> Handle(GetOriginalUrlQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.ShortKey))
        {
            throw new NotFoundException(request.ShortKey);
        }

        var shortLink = await _shortLinkRepository.GetShortLinkByShortKeyAsync(request.ShortKey);

        if (shortLink is null)
        {
            throw new NotFoundException(request.ShortKey);
        }

        var click = await _clickRepository.GetClickByIpAndShortKeyAsync(request.IP, shortLink.Id);

        if (click is null)
        {
            click = new Click
            {
                Ip = request.IP,
                ShortLinkId = shortLink.Id,
                IsActive = true
            };
            await _clickRepository.CreateClickAsync(click);
        }

        var link = await _linkRepository.GetLinkByShortKeyAsync(request.ShortKey);

        return new GetOriginalUrlDto(link.Url);
    }
}
