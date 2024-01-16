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
        if (string.IsNullOrEmpty(request.shortKey))
        {
            throw new NotFoundException(request.shortKey);
        }

        var shortLink = await _shortLinkRepository.GetShortLinkByShortKeyAsync(request.shortKey);

        if (shortLink is null)
        {
            throw new NotFoundException(request.shortKey);
        }

        var click = await _clickRepository.GetClickByIpAndShortKeyAsync(request.ip, shortLink.Id);

        if (click is null)
        {
            click = new Click
            {
                Ip = request.ip,
                ShortLinkId = shortLink.Id,
                IsActive = true
            };
            await _clickRepository.CreateClickAsync(click);
        }

        var link = await _linkRepository.GetLinkByShortKeyAsync(request.shortKey);

        return new GetOriginalUrlDto(link.Url);
    }
}
