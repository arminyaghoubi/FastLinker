using MediatR;

namespace FastLinker.Application.Features.Shortener.Queries.GetOriginalUrl;

public record GetOriginalUrlQuery(string shortKey, string ip) : IRequest<GetOriginalUrlDto>;
