using FastLinker.Application.Contracts.Persistence;
using FastLinker.Application.Contracts.Services;
using FastLinker.Application.Exceptions;
using FastLinker.Application.Resources;
using FastLinker.Domain;
using MediatR;

namespace FastLinker.Application.Features.Shortener.Commands;

public class CreateShortLinkCommandHandler : IRequestHandler<CreateShortLinkCommand, string>
{
    private readonly IShortLinkRepository _shortLinkRepository;
    private readonly ILinkRepository _linkRepository;
    private readonly IUrlShortenerService _shortenerService;

    public CreateShortLinkCommandHandler(IShortLinkRepository shortLinkRepository,
        ILinkRepository linkRepository,
        IUrlShortenerService shortenerService)
    {
        _shortLinkRepository = shortLinkRepository;
        _linkRepository = linkRepository;
        _shortenerService = shortenerService;
    }

    public async Task<string> Handle(CreateShortLinkCommand request, CancellationToken cancellationToken)
    {
        CreateShortLinkCommandValidation validation = new();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(ErrorMessageResource.BadRequest, validationResult);
        }

        var link = await _linkRepository.GetLinkByUrlAsync(request.Url);


        if (link is null)
        {
            link = new Link
            {
                Url = request.Url,
                IsActive = true
            };
            await _linkRepository.CreateLinkAsync(link);
        }

        if (request.Title is not null)
        {
            var shortLink = await _shortLinkRepository.GetShortLinkByTitleAndUrlAsync(request.Title, link.Id);

            if (shortLink is null)
            {
                shortLink = new ShortLink
                {
                    Title = request.Title,
                    LinkId = link.Id,
                    ShortKey = _shortenerService.ShortenUrl(link.Url),
                    IsActive = true
                };
                await _shortLinkRepository.CreateShortLinkAsync(shortLink);
            }

            return shortLink.ShortKey;
        }
        else
        {
            var shortLink = new ShortLink
            {
                LinkId = link.Id,
                ShortKey = _shortenerService.ShortenUrl(link.Url),
                IsActive = true
            };
            await _shortLinkRepository.CreateShortLinkAsync(shortLink);

            return shortLink.ShortKey;
        }
    }
}
