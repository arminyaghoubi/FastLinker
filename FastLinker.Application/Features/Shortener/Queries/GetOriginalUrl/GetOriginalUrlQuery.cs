using MediatR;

namespace FastLinker.Application.Features.Shortener.Queries.GetOriginalUrl;

public record GetOriginalUrlQuery(string ShortKey, string IP) : IRequest<GetOriginalUrlDto>;
